using System.Net.Mail;
using System.Net;
using Streaming.Domain.Entities;

namespace Streaming.Application.Services
{
    public class EmailServices
    {
        public static void SendEmail(EmailSender sender, string to, string subject, string body, Dictionary<string, byte[]>? attachments = null)
        {
            var message = new MailMessage(sender.Email, to, subject, body)
            {
                IsBodyHtml = true
            };

            if (attachments is not null)
            {
                foreach (var item in attachments)
                {
                    var ms = new MemoryStream(item.Value);
                    var attachment = new Attachment(ms, item.Key);

                    message.Attachments.Add(attachment);
                }
            }

            var smtpClient = new SmtpClient(sender.Smtp)
            {
                Port = sender.Port,
                Credentials = new NetworkCredential(sender.Email, sender.Password),
                EnableSsl = sender.Ssl
            };

            smtpClient.Send(message);
        }
    }
}
