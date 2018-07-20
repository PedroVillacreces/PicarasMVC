using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;

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
        public async Task<ActionResult> Register([Bind(Include = "CustomerId,Name,LastName,Address,Country,PostCode,City,Region,Birthday,Phone,Email, UserName, Password")] Customer customer)
        {
            customer.CodeActive = GeneratedCodeAttribute();
            customer.Active = false;
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return View("~/Views/Home/Index.cshtml");
        }

        private static string GeneratedCodeAttribute()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}