using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace PicarasMVCShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult SendEmail()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendData()
        {
            var fromAddress = new MailAddress("pedrovillacreces@gmail.com", "Cliente Picaras Closet");
            var toAddress = new MailAddress("pedrovillacreces@gmail.com", "Receptor");
            const string fromPassword = "4perrosladran";
            var subject = this.Request["Subject"];
            var body = this.Request["Message"];
           
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                Bcc = { new MailAddress(this.Request["Email"])}
            })
            {
                smtp.Send(message);
            }
            return View();
        }
    }
}