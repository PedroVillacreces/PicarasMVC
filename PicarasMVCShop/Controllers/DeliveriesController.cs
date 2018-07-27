using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;
using Picaras.Model.ViewModels;

namespace PicarasMVCShop.Controllers
{
    public class DeliveriesController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();
        // GET: Deliveries
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SavedOrder(Order orderProduct)
        {
            var customer = (Customer) Session["user"];
            var cart = (List<ProductCartViewModel>)Session["cart"];
            orderProduct.OrderDay = DateTime.Now;
            orderProduct.Amount = cart.Select((x => x.Product.Price * x.ShoppingCart.Quantity)).Sum();
            orderProduct.CustomerId = customer.CustomerId;
            var agent = _db.AgentTransports.FirstOrDefault(x => x.Price == orderProduct.AgentPrice);
            if (agent != null) orderProduct.AgentTransportId = agent.AgentTransportId;
            _db.Orders.Add(orderProduct);
            _db.SaveChanges();
            var orderSaved = _db.Orders.Find(orderProduct.OrderId);
           
            foreach (var item in cart)
            {
                if (orderSaved != null)
                    _db.OrderProduct.Add(
                        new OrderProduct
                        {
                            ProductId = item.Product.ProductId,
                            OrderId = orderSaved.OrderId,
                            Quantity = item.ShoppingCart.Quantity
                        });
                _db.SaveChanges();
            }
            Session.Remove("cart");
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}