using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;
using Picaras.Model.ViewModels;
using PicarasMVCShop.Helpers;

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
                var product = _db.Products.Find(item.Product.ProductId);
                product.Quantity = product.Quantity - item.ShoppingCart.Quantity;
                product.NumberOfSales = product.NumberOfSales + item.ShoppingCart.Quantity;
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();                
            }
            Session.Remove("cart");
            if (orderProduct.Payments == "bankTransfer")
            {
                var subject = $"Order de pago pedido: {orderProduct.OrderId}";
                var message = @"<html> 
                        <body>
                          <h3>Hola, " + customer.Name + @"</h3>
                          <h3>¡Gracias por confiar en Pícaras Closet!</h3>
                          <p>Le recordamos que el pago tiene que hacer efectivo, dentro de los primeros 7 días desde la realización del pedido.</p> 
                          <p>El número de cuenta para la realización del pedido es el: xxx-xxx-xxxxxx</p> 
                          <p>Le recordamos que el importe total a pagar es de " + orderProduct.Amount + @"€</p>
                          <p>Saludos desde el equipo de Pícatas Closet!</p>
                        </body> 
                      </html>";
                var toAddress = customer.Email;
                var CC = "pedrovillacreces@gmail.com";
                SenderEmails.Sender(subject, message, toAddress, CC);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}