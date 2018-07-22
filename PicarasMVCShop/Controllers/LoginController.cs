using System.Linq;
using System.Web.Mvc;
using Picaras.Model;

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
    }
}