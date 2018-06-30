using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;

namespace PicarasMVC.Controllers
{
    public class SubcategoriesController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();

        // GET: Subcategories
        public async Task<ActionResult> Index()
        {
            var subCategories = _db.SubCategories.Include(s => s.Category);
            return View(await subCategories.ToListAsync().ConfigureAwait(false));
        }

        // GET: Subcategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory subcategory = await _db.SubCategories.FindAsync(id).ConfigureAwait(false);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // GET: Subcategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SubcategoryId,Name,Description,CategoryId")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                _db.SubCategories.Add(subcategory);
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory subcategory = await _db.SubCategories.FindAsync(id).ConfigureAwait(false);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // POST: Subcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SubcategoryId,Name,Description,CategoryId")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(subcategory).State = EntityState.Modified;
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subcategory = await _db.SubCategories.FindAsync(id).ConfigureAwait(false);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var subcategory = await _db.SubCategories.FindAsync(id).ConfigureAwait(false);
            if (subcategory != null) _db.SubCategories.Remove(subcategory);
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
