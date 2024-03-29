﻿using Common.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleteMethodPattern.Contracts.OrderProcess
{
    //As we knnow, comments should minimal in a class, however, here are lots of comments in this code, because, 
    // this code is learning purpose. Not a production code.
    public abstract class AbstractOrderProcessor
    {
        public async Task ProcessOrder(IOrder order)
        {
            List<string> errors=new List<string>();
            //Here is basic steps of ProcessOrder  
            // Sequences should be like this because this is what the ProcessOrder algorithm is. 
            Console.WriteLine("Start processing order...");
            errors.AddRange(CheckOrderStatus(order));
            errors.AddRange(CheckItemDocuments(order));
            errors.AddRange(AdditionalValidation(order));
            //If we need to check the weather or update any price of any item using current currency value 
            //then We can adde CheckWeather Method and update price and calculate item depending on current currency rate
            // by adding mew method call UpdatePrice/CalculatePrice
            errors.AddRange(await SendEmailAsync(order));
            errors.AddRange(await SendPhoneAlertAsync(order));
            FinalizeOrder(errors);
            Console.WriteLine("Order processing completed.");
        }

        protected abstract List<string> AdditionalValidation(IOrder order);
        protected abstract List<string> CheckOrderStatus(IOrder order);
        protected abstract List<string> CheckItemDocuments(IOrder order);
        
        protected async virtual Task<List<string>> SendEmailAsync(IOrder order)
        {
            //By deafult do not send any email
            //If needed then concrete class will decide how to and To whom the mails are going to be send
            return new List<string>();
        }
        protected async virtual Task<List<string>> SendPhoneAlertAsync(IOrder order)
        {
            //By deafult do not send any phone alert
            //If needed then concrete class will decide how to and To whom the phone alert are going to be send
            return new List<string>();
        }
        protected virtual void FinalizeOrder(List<string> errors)
        {
            if (errors.Count > 0)
            {
                Console.WriteLine($"Something went wrong:{string.Join(",", errors)}");
            }
            else
            {
                //If you need to do more complex task after checking the order
                // Perform that task in concrete class by overridding this FinalizeOrder method.
                Console.WriteLine("Order confirmed.");
            }
        }
    }
}
