using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;
using Picaras.Model.ViewModels;

namespace PicarasMVCShop.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();
        // GET: Shopping
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddtoCart(ShoppingCart shopping)
        {
            if (Session["cart"] == null)
            {
                var cart = new List<ProductCartViewModel>();
                var getProduct = _db.Products.Find(shopping.ProductCode);
                cart.Add(new ProductCartViewModel
                {
                    Product = getProduct,
                    ShoppingCart = shopping
                });
                Session["cart"] = cart;
            }
            else
            {
                var cart = (List<ProductCartViewModel>)Session["cart"];
                var index = IsExist(shopping.ProductCode);
                if (index != -1)
                {
                    cart[index].ShoppingCart.Quantity++;
                }
                else
                {
                    cart.Add(new ProductCartViewModel { Product = _db.Products.Find(shopping.ProductCode), ShoppingCart = shopping });
                }
                Session["cart"] = cart;
            }
            return Json(this.Session.Count, JsonRequestBehavior.AllowGet);
        }

        private int IsExist(int id)
        {
            var cart = (List<ProductCartViewModel>)Session["cart"];
            for (var i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductId.Equals(id))
                    return i;
            return -1;
        }
    }
}