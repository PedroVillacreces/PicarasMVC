using Picaras.Model;
using Picaras.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PicarasMVCShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MenuHeader()
        {
            var model = Getall();
            return PartialView(model);
        }

        public ActionResult Slider()
        {
            var model = GetSlider();
            return PartialView(model);
        }
        public ActionResult BestSeller()
        {
            var model = GetBestSeller();
            return PartialView(model);
        }
        public ActionResult MostRecent()
        {
            var model = GetRecentAdded();
            return PartialView(model);
        }

        private IEnumerable<Category> Getall()
        {
            return _db.Categories;
        }

        private IEnumerable<AdminSlider> GetSlider()
        {
            return _db.AdminSlider;
        }

        private IEnumerable<Product> GetBestSeller()
        {
            return _db.Products.OrderBy(x => x.NumberOfSales).Take(16);
        }

        private IEnumerable<Product> GetRecentAdded()
        {
            return _db.Products.OrderBy(x => x.CreateDateTime).Take(16);
        }
        
    }
}