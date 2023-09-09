using BuilderPattern.BuilderConcrete.NotificationBuilder;
using BuilderPattern;
using Common;
using Common.Contracts.Order;
using Common.Model.Order;
using PhoneService.Contracts;
using PhoneService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleteMethodPattern.Contracts.OrderProcess;
using EmailService.Contracts;
using EmailService.Services;
using Common.DTOs.Email;

namespace TempleteMethodPattern.Implementation.OrderProcess
{
    public class PurchaseOrderProcessor : AbstractOrderProcessor
    {
        private List<string> errorList = new List<string>();
        protected async override Task<List<string>> SendEmailAsync(IOrder order)
        {
            errorList = new List<string>();
            var orderPurchase = order as PurchaseOrder;
            await SendEmail(orderPurchase);
            return errorList;
        }
        private async Task SendEmail(PurchaseOrder? orderPurchase)
        {
            try
            {
                if (orderPurchase != null)
                {
                    var emailNotification = GenerateEmailNotification(orderPurchase);
                    IEmailSenderService serviceEmail = new MicrosoftEmailSenderService();
                    EmailConfigDto emailConfigDto = PrepareEmailConfig();
                    //This will send email to Suppliers
                    //await serviceEmail.SendEmailAsync(emailNotification, emailConfigDto);
                }
                else
                {
                    errorList.Add("Purchase Not Found");
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
        private Notification GenerateEmailNotification(PurchaseOrder order)
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

        protected async override Task <List<string>> SendPhoneAlertAsync(IOrder order)
        {
            errorList = new List<string>();
            var orderPurchase = order as PurchaseOrder;
            await SendPhoneAlert(orderPurchase);
            return errorList;
        }
        private async Task SendPhoneAlert(PurchaseOrder? orderPurchase)
        {
            try
            {
                if (orderPurchase != null)
                {
                    var mobileNotification = GeneratePhoneNotification(orderPurchase);
                    IPhoneAlertSenderService servicePhone = new PhoneAlertSenderService();
                    await servicePhone.SendPhoneAlertAsync(mobileNotification, new Common.DTOs.Phone.PhoneConfigDto());
                }
                else
                {
                    errorList.Add("Purchase Not Found");
                }
            }
            catch (Exception ex)
            {

                errorList.Add(ex.Message);
            }
        }
        private Notification GeneratePhoneNotification(PurchaseOrder order)
        {
            Notification noUseObj = new Notification();
            INotificationBuilder notificationPhone = new PhoneNotificationBuilder();
            NotificationBuilderDirector notificationDirector = new NotificationBuilderDirector();

            Dictionary<string, dynamic> notificationInfo = new Dictionary<string, dynamic>();
            notificationInfo.Add(nameof(noUseObj.PhoneNumbers), new string[2] { "0161111111", "0162222222" });
            notificationInfo.Add(nameof(noUseObj.NotificationSubject), "This is a Test Subject");
            //Here you can use template with dynamic feature for body
            notificationInfo.Add(nameof(noUseObj.NotificationBody), $"This is a Notification body OrderNo:{order.OrderNo} ,TenderNo :{order.TenderNo}");

            notificationDirector.BuildNotification(notificationPhone, notificationInfo);
            Notification finalNotification = notificationPhone.GetNotification();

            return finalNotification;
        }
     
        protected override List<string> AdditionalValidation(IOrder order)
        {
            errorList = new List<string>();
            var orderPurchase = order as PurchaseOrder;
            if (orderPurchase != null)
            {
                ValidateTender(orderPurchase);
                //you can add for Validation
            }
            return errorList;
        }
        private void ValidateTender(PurchaseOrder? orderPurchase)
        {
            if (string.IsNullOrWhiteSpace(orderPurchase?.TenderNo))
            {
                //You can check other parameters to check Active tender.
                errorList.Add("TenderNo is not valid");
            }
        }
        
        protected override List<string> CheckItemDocuments(IOrder order)
        {
            errorList = new List<string>();
            foreach (var item in order.OrderItems)
            {
                if ((item.ItemDocuments?.Count() ?? 0) == 0)
                {
                    errorList.Add($"PO:{order.OrderNo} Item: {item.ItemName}, Unit:{item.Unit} Document Not Found.");
                }
            }
            return errorList;
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
            return order.Status == Common.OrderStatus.Approved
                   || order.Status == Common.OrderStatus.ForceApproved;
        }
    }
}
