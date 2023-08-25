using Common;
using Common.DTOs.Email;
using EmailService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Services
{
    public class GoogleEmailSenderService : IEmailSenderService
    {
        public async Task SendEmailAsync(Notification notification, EmailConfigDto emailConfigDto)
        {
            SmtpClient smtpClient = PrepareSmtpClient(emailConfigDto);
            MailMessage mailMessage = PrepareMailMessage(notification, emailConfigDto);
            AddToEmails(notification, mailMessage);
            AddToCcEmails(notification, mailMessage);
            AddToBccEmails(notification, mailMessage);
            AddAttachments(notification, mailMessage);

            await smtpClient.SendMailAsync(mailMessage);
        }

        private static MailMessage PrepareMailMessage(Notification notification, EmailConfigDto emailConfigDto)
        {
            return new MailMessage
            {
                From = new MailAddress(emailConfigDto.FromEmail),
                Subject = notification.NotificationSubject,
                Body = notification.NotificationBody,
                IsBodyHtml = emailConfigDto.IsBodyHtml,
            };
        }

        private static SmtpClient PrepareSmtpClient(EmailConfigDto emailConfigDto)
        {
            return new SmtpClient("smtp.gmail.com")
            {
                Port = int.Parse(emailConfigDto.Port),
                Credentials = new NetworkCredential(emailConfigDto.FromEmail, emailConfigDto.Password),
                EnableSsl = emailConfigDto.EnableSsl,
            };
        }

        private void AddAttachments(Notification notification, MailMessage mailMessage)
        {
            if (notification.AttachmentPaths.Length > 0)
            {
                foreach (var attachmentPath in notification.AttachmentPaths)
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }
        }
        private void AddToBccEmails(Notification notification, MailMessage mailMessage)
        {
            if (notification.BCCEmails.Length > 0)
            {
                foreach (var email in notification.BCCEmails)
                {
                    mailMessage.Bcc.Add(email);
                }
            }
        }
        private void AddToCcEmails(Notification notification, MailMessage mailMessage)
        {
            if (notification.CCEmails.Length > 0)
            {
                foreach (var email in notification.CCEmails)
                {
                    mailMessage.CC.Add(email);
                }
            }
        }
        private void AddToEmails(Notification notification, MailMessage mailMessage)
        {
            if (notification.Emails.Length > 0)
            {
                foreach (var email in notification.Emails)
                {
                    mailMessage.To.Add(email);
                }
            }
        }
    }
}
