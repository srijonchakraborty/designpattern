using BuilderPattern.BuilderConcrete.NotificationBuilder;
using Common.Contracts.Order;
using Common.DTOs.Email;
using Common.Model.Order;
using EmailService.Contracts;
using EmailService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleteMethodPattern.Contracts.OrderProcess;
using BuilderPattern.BuilderInterface;
using Common.Model;
using BuilderPattern.BuilderDirectors;

namespace TempleteMethodPattern.Implementation.OrderProcess
{
    public class LCOrderProcessor : AbstractOrderProcessor
    {
        private List<string> errorList = new List<string>();

        protected async override Task<List<string>> SendEmailAsync(IOrder order)
        {
            errorList = new List<string>();
            var orderLC = order as LC;
            await SendEmail(orderLC);
            return errorList;
        }
        private async Task SendEmail(LC? orderLC)
        {
            try
            {
                if (orderLC != null)
                {
                    var emailNotification = GenerateEmailNotification(orderLC);
                    IEmailSenderService serviceEmail = new MicrosoftEmailSenderService();
                    EmailConfigDto emailConfigDto = PrepareEmailConfig();
                    //This will send email to Suppliers
                    //await serviceEmail.SendEmailAsync(emailNotification, emailConfigDto);
                }
                else
                {
                    errorList.Add("LC Not Found");
                }
            }
            catch (Exception ex)
            {

                errorList.Add(ex.Message);
            }
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
                SmtpClientUrl = "smtp.office365.com"
            };
            return emailConfigDto;
        }
        private Notification GenerateEmailNotification(LC order)
        {
            Notification noUseObj = new Notification();
            INotificationBuilder notificationEmail = new EmailNotificationBuilder();
            NotificationBuilderDirector notificationDirector = new NotificationBuilderDirector();

            Dictionary<string, dynamic> notificationInfo = new Dictionary<string, dynamic>();
            PrepareCcEmails(notificationInfo, nameof(noUseObj.CCEmails), order);
            notificationInfo.Add(nameof(noUseObj.Emails), new string[] { order.ClientEmail });
            notificationInfo.Add(nameof(noUseObj.NotificationSubject), "This is a LC Subject");
            notificationInfo.Add(nameof(noUseObj.NotificationBody), GetEmailBody(order));

            notificationDirector.BuildNotification(notificationEmail, notificationInfo);

            Notification finalNotification = notificationEmail.GetNotification();

            return finalNotification;
        }
        private void PrepareCcEmails(Dictionary<string, dynamic> notificationInfo, string key, LC order)
        {
            var emails = order?.OrderItems?.Select(c => c.SupplierEmail)?.ToArray();
            if (order != null && emails != null)
            {
                notificationInfo.Add(key, emails);
            }
        }
        private string GetEmailBody(LC order)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($@"LC Order:{order.OrderNo} , Date:{order.CreateDate} Bank: {order.BankName}");
            result.AppendLine($@"Item List");
            result.AppendLine($@"--------------");
            int count = 1;
            foreach (var orderItem in order.OrderItems)
            {
                result.AppendLine($@"{count}. Item:{orderItem.ItemName} Unit: {orderItem.Unit} Quantity: {orderItem.Quantity} Price: {orderItem.Price}");
            }
            return result.ToString();
        }

        protected override List<string> AdditionalValidation(IOrder order)
        {
            errorList = new List<string>();
            var orderLC = order as LC;
            if (orderLC != null)
            {
                ValidateBankInfo(orderLC);
                //you can add for Validation
            }
            return errorList;
        }
        private void ValidateBankInfo(LC? orderLC)
        {
            if (string.IsNullOrWhiteSpace(orderLC?.BankName))
            {
                //You can check other parameters to check Active tender.
                errorList.Add("BankName is not valid");
            }
        }
        
        protected override List<string> CheckItemDocuments(IOrder order)
        {
            errorList = new List<string>();
            foreach (var item in order.OrderItems)
            {
                if ((item.ItemDocuments?.Count() ?? 0) == 0)
                {
                    errorList.Add($"LC:{order.OrderNo} Item: {item.ItemName}, Unit:{item.Unit} Document Not Found.");
                }
            }
            throw new NotImplementedException();
        }

        protected override List<string> CheckOrderStatus(IOrder order)
        {
            errorList = new List<string>();
            if (!checkStatus(order))
            {
                errorList.Add("Status is not in Approved,ForceApproved");
            }
            return errorList;
        }
        private static bool checkStatus(IOrder order)
        {
            return order.Status == Common.OrderStatus.Approved;
        }
    }
}
