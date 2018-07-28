using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Picaras.Model;
using Picaras.Model.Entities;
using Picaras.Model.ViewModels;
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
            var user = (Customer)Session["user"];
            var orders = _db.Orders.Where(x => x.CustomerId == user.CustomerId);

            return PartialView(new CustomersOdersViewModel
            {
                Customer = user,
                Orders = orders
            });
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

        [HttpPost]
        public ActionResult EditPersonalData(Customer customer)
        {
            var user = _db.Customers.Find(customer.CustomerId);
            if (user != null)
            {
                user.Name = customer.Name;
                user.LastName = customer.LastName;
                user.Birthday = customer.Birthday;
                user.UserName = customer.UserName;
                user.Email = customer.Email;
                user.Phone = customer.Phone;
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return View("~/Views/Login/UserMenu.cshtml", user);
        }

        [HttpPost]
        public ActionResult EditAddressData(Customer customer)
        {
            var user = _db.Customers.Find(customer.CustomerId);
            if (user != null)
            {
                user.Address = customer.Address;
                user.City = customer.City;
                user.Region = customer.Region;
                user.PostCode = customer.PostCode;
                user.Country = customer.Country;
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return View("~/Views/Login/UserMenu.cshtml", user);
        }

        [HttpPost]
        public JsonResult ShowDelivery(int id)
        {
            _db.Configuration.ProxyCreationEnabled = false;
            var orderProducts = _db.OrderProduct.Where(x => x.OrderId == id);
            var returnOrderProducts = new List<OrderProduct>();
            foreach (var item in orderProducts)
            {
                returnOrderProducts.Add(new OrderProduct
                {
                    Quantity = item.Quantity,
                    Product = _db.Products.Find(item.ProductId),
                    Order = _db.Orders.Find(item.OrderId)
                });
            }
            return Json(returnOrderProducts, JsonRequestBehavior.AllowGet);

        }
    }
}