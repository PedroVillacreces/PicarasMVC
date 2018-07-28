using System.Linq;
using System.Web.Mvc;
using MoreLinq;
using Picaras.Model;

namespace PicarasMVCShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowByCategory(int id)
        {
            var products = _db.Products.Where(x => x.CategoryId == id && x.Quantity > 0)
                .DistinctBy(x => x.ProductCode);
            ViewBag.Category = _db.Categories.Find(id)?.Name;
            return PartialView(products);
        }

        public ActionResult ShowBySubcategories(int id)
        {
            var products = _db.Products.Where(x => x.SubcategoryId == id && x.Quantity > 0)
                .GroupBy(x => x.ProductCode)
                .Select(x => x.FirstOrDefault());
            ViewBag.Subcategory = _db.SubCategories.Find(id)?.Name;
            return View(products);
        }
    }
}