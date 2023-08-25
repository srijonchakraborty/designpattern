using Common;
using Common.DTOs.Email;
using EmailService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Services
{
    public class MicrosoftEmailSenderService : IEmailSenderService
    {
        public async Task SendEmailAsync(Notification notification, EmailConfigDto emailConfigDto)
        {
            //TO DO
            throw new NotImplementedException();
        }
    }
}
