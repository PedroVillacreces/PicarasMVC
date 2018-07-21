using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using PicarasMVCShop.Helpers;

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
            SenderEmails.Sender(this.Request["Subject"], this.Request["Message"],
                "pedrovillacreces@gmail.com", this.Request["Email"]);
           
            return View();
        }
    }
}