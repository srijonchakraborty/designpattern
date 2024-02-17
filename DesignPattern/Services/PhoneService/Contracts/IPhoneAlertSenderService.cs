using Common.DTOs.Phone;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Contracts
{
    public interface IPhoneAlertSenderService
    {
        Task SendPhoneAlertAsync(Notification notification, PhoneConfigDto phoneConfigDto);
    }
}
