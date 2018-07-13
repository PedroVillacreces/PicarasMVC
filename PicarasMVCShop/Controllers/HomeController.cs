using Picaras.Model;
using Picaras.Model.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
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

        private IEnumerable<Category> Getall()
        {
            return _db.Categories;
        }

        private IEnumerable<AdminSlider> GetSlider()
        {
            return _db.AdminSlider;
        }
    }
}