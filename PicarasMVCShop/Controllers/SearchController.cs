using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MoreLinq;
using Picaras.Model;
using Picaras.Model.Entities;

namespace PicarasMVCShop.Controllers
{
    public class SearchController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();
        // GET: Search
 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchProduct()
        {
            var searchName = this.Request["Search"];
            var products = GetSearchProducts(searchName);
            return PartialView(products);
        }

        private IEnumerable<Product> GetSearchProducts(string productName)
        {
            return _db.Products.Where(x => x.Name.Contains(productName) && x.Quantity > 0)
                .DistinctBy(x => x.ProductCode)
                .OrderBy(x=> x.Price);
        }
    }
}