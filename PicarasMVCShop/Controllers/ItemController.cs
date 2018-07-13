using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;

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
            return PartialView(model);
        }

        private Product GetById(int id)
        {

            return _db.Products.Find(id);
        }
    }
}