using BuilderPattern.BuilderConcrete.NotificationBuilder;
using BuilderPattern.BuilderDirectors;
using BuilderPattern.BuilderInterface;
using Common.Contracts.Order;
using Common.Model;
using Common.Model.Order;
using PhoneService.Contracts;
using PhoneService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleteMethodPattern.Contracts.OrderProcess;

namespace TempleteMethodPattern.Implementation.OrderProcess
{
    public class SpotPurchaseProcessor : AbstractOrderProcessor
    {
        private List<string> errorList = new List<string>();
        
        protected async override Task<List<string>> SendPhoneAlertAsync(IOrder order)
        {
            errorList = new List<string>();
            var orderSpotPurchase = order as SpotPurchase;
            await SendPhoneAlert(orderSpotPurchase);
            return errorList;
        }
        private async Task SendPhoneAlert(SpotPurchase? orderSpotPurchase)
        {
            try
            {
                if (orderSpotPurchase != null)
                {
                    var mobileNotification = GenerateNotification(orderSpotPurchase);
                    IPhoneAlertSenderService servicePhone = new PhoneAlertSenderService();
                    await servicePhone.SendPhoneAlertAsync(mobileNotification, new Common.DTOs.Phone.PhoneConfigDto());
                }
                else
                {
                    errorList.Add("SpotPurchase Not Found");
                }
            }
            catch (Exception ex)
            {

                errorList.Add(ex.Message);
            }
        }
        private Notification GenerateNotification(SpotPurchase order)
        {
            Notification noUseObj = new Notification();
            INotificationBuilder notificationPhone = new PhoneNotificationBuilder();
            NotificationBuilderDirector notificationDirector = new NotificationBuilderDirector();

            Dictionary<string, dynamic> notificationInfo = new Dictionary<string, dynamic>();
            notificationInfo.Add(nameof(noUseObj.PhoneNumbers), new string[2] { "0161111111", "0162222222" });
            notificationInfo.Add(nameof(noUseObj.NotificationSubject), "This is a Test Subject");
            //Here you can use template with dynamic feature for body
            notificationInfo.Add(nameof(noUseObj.NotificationBody), $"This is a Notification body OrderNo:{order.OrderNo} ,InvoiceCashMemoNo :{order.InvoiceCashMemoNo}");

            notificationDirector.BuildNotification(notificationPhone, notificationInfo);
            Notification finalNotification = notificationPhone.GetNotification();

            return finalNotification;
        }
        
        protected override List<string> AdditionalValidation(IOrder order)
        {
            errorList = new List<string>();
            var orderSpotPurchase = order as SpotPurchase;
            if (orderSpotPurchase != null)
            {
                ValidateInvoiceCashMemoNo(orderSpotPurchase);
                //you can add for Validation
            }
            return errorList;
        }
        private void ValidateInvoiceCashMemoNo(SpotPurchase? orderSpotPurchase)
        {
            if (string.IsNullOrWhiteSpace(orderSpotPurchase?.InvoiceCashMemoNo))
            {
                errorList.Add("InvoiceCashMemoNo can not be empty");
            }
        }

        protected override List<string> CheckItemDocuments(IOrder order)
        {
            errorList = new List<string>();
            //No need to check documents for items
            return errorList;
        }

        protected override List<string> CheckOrderStatus(IOrder order)
        {
            errorList = new List<string>();
            if (!checkStatus(order))
            {
                errorList.Add("Status is not in Approved,ForceApproved or in Forward");
            }
            return errorList;
        }
        private static bool checkStatus(IOrder order)
        {
            return order.Status == Common.OrderStatus.Approved
                   || order.Status == Common.OrderStatus.ForceApproved
                   || order.Status == Common.OrderStatus.Forward;
        }
    }
}
