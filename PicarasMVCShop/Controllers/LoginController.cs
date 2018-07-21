using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicarasMVCShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginUser()
        {
            return PartialView();
        }
        //[HttpPost]
        //public JsonResult LoginPage(string user, string pass)
        //{

        //    //return PartialView();
        //}
    }
}