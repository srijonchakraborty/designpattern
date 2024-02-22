using Common.DTOs.Phone;
using Common.Model;
using PhoneService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Implementations
{
    public class PhoneAlertSenderService : IPhoneAlertSenderService
    {
        public Task SendPhoneAlertAsync(Notification notification, PhoneConfigDto phoneConfigDto)
        {
            //Send Phone Notification From here
            return Task.CompletedTask;
        }
    }
}
