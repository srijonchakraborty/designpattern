using Common;
using Common.DTOs.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Contracts
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(Notification notification, EmailConfigDto emailConfigDto);
    }
}
