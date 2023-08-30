using BuilderPattern;
using BuilderPattern.BuilderConcrete.NotificationBuilder;
using Common;
using Common.DTOs.Email;
using Common.Model.Order;
using DecoratorPattern.Contracts;
using EmailService.Contracts;
using EmailService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decoretors.PurchaseOrderDecoretor
{

    public class EmailNotificationDecorator : IPurchaseOrderDecorator
    {
        public void Apply(PurchaseOrder order)
        {
            var notification = GenerateNotification(order);

            IEmailSenderService emailSenderService = new MicrosoftEmailSenderService();
            EmailConfigDto emailConfigDto = PrepareEmailConfig();
            emailSenderService.SendEmailAsync(notification, emailConfigDto);
        }

        private Notification GenerateNotification(PurchaseOrder order)
        {
            Notification noUseObj = new Notification();
            INotificationBuilder notificationEmail = new EmailNotificationBuilder();
            NotificationBuilderDirector notificationDirector = new NotificationBuilderDirector();

            Dictionary<string, dynamic> notificationInfo = new Dictionary<string, dynamic>();
            PrepareCcEmails(notificationInfo, nameof(noUseObj.CCEmails), order);
            notificationInfo.Add(nameof(noUseObj.Emails), new string[] { order.ClientEmail });
            notificationInfo.Add(nameof(noUseObj.NotificationSubject), "This is a Test Subject");
            notificationInfo.Add(nameof(noUseObj.NotificationBody), GetEmailBody(order));

            notificationDirector.BuildNotification(notificationEmail, notificationInfo);

            Notification finalNotification = notificationEmail.GetNotification();

            return finalNotification;
        }

        private void PrepareCcEmails(Dictionary<string, dynamic> notificationInfo, string key, PurchaseOrder order)
        {
            var emails = order?.OrderItems?.Select(c => c.SupplierEmail)?.ToArray();
            if (order != null && emails != null)
            {
                notificationInfo.Add(key, emails);
            }
        }

        private string GetEmailBody(PurchaseOrder order)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($@"Purchase Order:{order.OrderNo} , Date:{order.CreateDate} Total Cost: {order.TotalCost}");
            result.AppendLine($@"Other: Tax:{order.TaxAmount}, Shipping Fee:{order.ShippingFee}, Discount:{order.DiscountAmount}");
            result.AppendLine($@"Tender No: {order.TenderNo}");
            result.AppendLine($@"Item List");
            result.AppendLine($@"--------------");
            int count = 1;
            foreach (var orderItem in order.OrderItems)
            {
                result.AppendLine($@"{count}. Item:{orderItem.ItemName} Unit: {orderItem.Unit} Quantity: {orderItem.Quantity} Price: {orderItem.Price}");
            }
            return result.ToString();
        }

        private EmailConfigDto PrepareEmailConfig()
        {
            EmailConfigDto emailConfigDto = new EmailConfigDto()
            {
                EnableSsl = true,
                FromEmail = "srijonchak@live.com",
                IsBodyHtml = false,
                Port = 587,
                Password = "123456789",
                SmtpClientUrl = ""
            };
            return emailConfigDto;
        }
    }
}
