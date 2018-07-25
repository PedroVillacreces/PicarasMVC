using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;
using Picaras.Model.ViewModels;

namespace PicarasMVCShop.Controllers
{

    public class ItemController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProduct(int id)
        {
            var model = GetById(id);
            var sizes = GetSizes(model.ProductCode);
            var agents = GetAgents();
            var productSize = new ProductSize
            {
                Product = model,
                Sizes = sizes,
                Transports = agents
            };
            return PartialView(productSize);
        }

        private Product GetById(int id)
        {
            return _db.Products.Find(id);
        }

        private IEnumerable<string> GetSizes(int productCode)
        {
            var product = _db.Products.Where(x => x.ProductCode == productCode);
            return product.Select(x => x.Size);

        }

        private IEnumerable<AgentTransport> GetAgents()
        {
            return _db.AgentTransports;
        }

        public JsonResult GetQuantity(int ProductCode)
        {
            var products = _db.Products.Find(ProductCode).Quantity;
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQuantityBySize(int pc, string size)
        {
            var products = _db.Products.FirstOrDefault(x => x.ProductCode == pc && x.Size == size);
            return Json(new 
            {
                Id = products.ProductId,
                Quantity = products.Quantity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}