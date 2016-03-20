using Dolphin.Domain;
using Dolphin.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string body)
        {
            var email = new MailMessage
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            email.To.Add(to);

            Send(email);

            email.Dispose();
        }

        public void Send(MailMessage email)
        {
            email.From = new MailAddress("noreply@dolphin.com", "Dolphin  Charity Foundation");
            email.Sender = new MailAddress("noreply@dolphine.com", "Dolphin  Charity Foundation");

            email.Bcc.Add("dolphincharity@yopmail.com");

            using (var client = new SmtpClient())
            {
                client.Send(email);
            }
        }
    }
}
