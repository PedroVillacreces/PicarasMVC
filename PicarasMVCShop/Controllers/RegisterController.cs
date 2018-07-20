using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        public async Task<ActionResult> Register([Bind(Include = "CustomerId,Name,LastName,Address,Country,PostCode,City,Region,Phone,Email")] Customer customer)
        {
            if (!ModelState.IsValid) return View("~/Views/Register/AddUser.cshtml");
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return View("~/Views/Home/Index.cshtml");

        }
    }
}