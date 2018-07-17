using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult GetShoppingCounter()
        {
            var totalItems = (List<ProductCartViewModel>)Session["cart"];
            if (totalItems != null && totalItems.Any())
            {
                var totalNumberList = totalItems.Select(x => x.ShoppingCart.Quantity);
                ViewBag.totalNumber = totalNumberList.Sum();
            }
            else
            {
                ViewBag.totalNumber = 0;
            }

            return PartialView();
        }

        public ActionResult ShowShoppingCart()
        {
            var shoppingCart = (IEnumerable<ProductCartViewModel>)Session["cart"];
            return PartialView(shoppingCart);
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
                var cart = (List<ProductCartViewModel>) Session["cart"];
                var index = IsExist(shopping.ProductCode);
                if (index != -1)
                {
                    cart[index].ShoppingCart.Quantity += shopping.Quantity;
                }
                else
                {
                    cart.Add(new ProductCartViewModel
                    {
                        Product = _db.Products.Find(shopping.ProductCode),
                        ShoppingCart = shopping
                    });
                }

                Session["cart"] = cart;
            }

            var totalItems = (List<ProductCartViewModel>) Session["cart"];
            var totalNumberList = totalItems.Select(x => x.ShoppingCart.Quantity);
            var totalNumber = totalNumberList.Sum();

            return Json(totalNumber, JsonRequestBehavior.AllowGet);

        }

        public JsonResult RemoveToCart(ShoppingCart shopping)
        {
            var message = "Borrado";
            var cart = (List<ProductCartViewModel>) Session["cart"];
            var productDelete = cart.FirstOrDefault(x => x.ShoppingCart.ProductCode == shopping.ProductCode);
            cart.Remove(productDelete);
            Session["cart"] = cart;
            if (cart.Contains(productDelete))
            {
                message = "Error";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
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