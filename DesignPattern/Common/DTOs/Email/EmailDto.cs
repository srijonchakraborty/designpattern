using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Email
{
    public class EmailConfigDto
    {
       public string FromEmail { get; set; }
       public string Password { get; set; }
       public string SmtpClientUrl { get; set; }
       public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
