using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MoreLinq;
using Picaras.Model;
using Picaras.Model.Entities;

namespace PicarasMVCShop.Controllers
{
    public class OutletController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();
        // GET: Outlet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Outlets()
        {
            var outletItems = GetOutletItems();
            return PartialView(outletItems);
        }

        private IEnumerable<Product> GetOutletItems()
        {
            return _db.Products.Where(x => x.IsOutlet && x.Quantity > 0)
                .DistinctBy(x => x.ProductCode)
                .OrderBy(x=>x.Price);
        }
    }
}