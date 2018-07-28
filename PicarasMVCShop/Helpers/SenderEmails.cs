using System.Net;
using System.Net.Mail;

namespace PicarasMVCShop.Helpers
{
    public class SenderEmails
    {
        public static void Sender(string subject, string message, string toAddress, string emailCc)
        {
            var fromAddress = new MailAddress("pedrovillacreces@gmail.com", "Cliente Picaras Closet");
            var toAddressMail = new MailAddress(toAddress, "Receptor");
            const string fromPassword = "4perrosladran";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var messageToSend = new MailMessage(fromAddress, toAddressMail)
            {
                Subject = subject,              
                IsBodyHtml = true,
                Body = message,
                Bcc = { new MailAddress(emailCc) }
            })
            {
                smtp.Send(messageToSend);
            }
        }
    }
}