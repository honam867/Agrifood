using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private SmtpClient _smtpClient;
        public EmailSender(
            IOptions<EmailSettings> emailSettings
            )
        {
            _emailSettings = emailSettings.Value;
            _smtpClient = new SmtpClient()
            {
                Host = _emailSettings.MailServer,
                Port = _emailSettings.MailPort,
                EnableSsl = _emailSettings.EnableSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(_emailSettings.Sender, _emailSettings.Password),
                Timeout = _emailSettings.Timeout
            };
        }
        public async Task SendEmailAsync(string email, string subject, string message, bool isHtml)
        {
            try
            {
                var mailMessage = new MailMessage(new MailAddress(_emailSettings.Sender, _emailSettings.SenderName), new MailAddress(email));
                mailMessage.Body = message;
                if (isHtml)
                {
                    mailMessage.IsBodyHtml = true;
                }
                mailMessage.Subject = subject;
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

    }
}
