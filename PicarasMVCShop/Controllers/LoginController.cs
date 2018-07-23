using System.Linq;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;
using PicarasMVCShop.Helpers;

namespace PicarasMVCShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginUser()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult LoginPage(string UserName, string Password)
        {
            var getUser = _db.Customers.FirstOrDefault(x => x.UserName == UserName);
            if (getUser == null || getUser.Password != Password) return Json(false);
            Session["user"] = getUser;
            return Json(true);
        }

        public ActionResult LogOut()
        {
            Session.Remove("user");
            Session.Remove("cart");
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult UserMenu()
        {
            var user = (Customer) Session["user"];
            return PartialView(user);
        }
  
        [HttpPost]
        public ActionResult SendEmailToReset(string email)
        {
            var user = _db.Customers.FirstOrDefault(x => x.Email == email);
            if (user == null) return View("~/Views/Login/WrongEmail.cshtml");
            const string subject = "Su usuario y contraseña Pícaras";
            var message =
                $"Su usurio es: {user.UserName} y su password: {user.Password}";
            var toAddress = user.Email;
            const string emailCc = "pedrovillacreces@gmail.com";
            SenderEmails.Sender(subject, message, toAddress, emailCc);
            return View("~/Views/Login/PasswordSent.cshtml");

        }

        public ActionResult RememberPassword()
        {
            return PartialView();
        }
    }
}