using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;
using PicarasMVCShop.Helpers;

namespace PicarasMVCShop.Controllers
{
    /// <summary>
    /// cc
    /// </summary>
    public class RegisterController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Register([Bind(Include = "CustomerId,Name,LastName,Address,Country,PostCode,City,Region,Birthday,Phone,Email,UserName,Password,ConfirmPassword")] Customer customer)
        {
            customer.CodeActive = GeneratedCodeAttribute();
            customer.Active = false;
           
            var messege = "El código de activación de la cuenta es el: " + customer.CodeActive;
            SenderEmails.Sender("Código Activación de Pícaras", messege,
                customer.Email, "pedrovillacreces@gmail.com");
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return View("~/Views/Register/ActivateAccount.cshtml", customer);
        }

        [HttpPost]
        public ActionResult ActivateAccount(int customerId, string code)
        {
            var user = _db.Customers.Find(customerId);
            if (user == null || user.CodeActive != code) return View("~/Views/Register/ActivateAccount.cshtml");
            user.Active = true;
            _db.Entry(user).Property("Active").IsModified = true;
            _db.SaveChanges();
            return View("~/Views/Login/Index.cshtml");

        }

        private static string GeneratedCodeAttribute()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [HttpPost]
        public ActionResult ActiveAccount(int userId, string code)
        {
            var user =_db.Customers.Find(userId);
            if (user == null || user.CodeActive != code) return View("~/Views/Register/Index.cshtml");
            user.Active = true;
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public JsonResult DoesUserNameExist(string userName)
        {
            var user = _db.Customers.FirstOrDefault(x => x.UserName == userName);
            return Json(user == null);
        }
    }
}