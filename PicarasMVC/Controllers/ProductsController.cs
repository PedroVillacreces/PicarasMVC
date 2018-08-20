using System;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;

namespace PicarasMVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            var products = _db.Products.Include(p => p.Category).Include(p => p.Subcategory);
            return View(await products.ToListAsync().ConfigureAwait(false));
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _db.Products.FindAsync(id).ConfigureAwait(false);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            ViewBag.SubcategoryId = new SelectList(_db.SubCategories, "SubcategoryId", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,Name,Description,Quantity,Active,Price,Picture,CreateDateTime,OldPrice,CategoryId,SubcategoryId,IsOutlet, Size, ProductCode")] Product product)
        {
            if (ModelState.IsValid)
            {
                var fileContent = Request.Files["Picture"];
                if (!string.IsNullOrEmpty(fileContent.FileName))
                {
                    var stream = fileContent.InputStream;
                    var fileName = Path.GetFileName(fileContent.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    using (var fileStream = System.IO.File.Create(path))
                    {
                            await stream.CopyToAsync(fileStream).ConfigureAwait(false);
                    }
                    product.Picture = $"/Content/Images/{fileName}";
                }
                product.CreateDateTime = DateTime.Now;
                _db.Products.Add(product);
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", product.CategoryId);
            ViewBag.SubcategoryId = new SelectList(_db.SubCategories, "SubcategoryId", "Name", product.SubcategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = await _db.Products.FindAsync(id).ConfigureAwait(false);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", product.CategoryId);
            ViewBag.SubcategoryId = new SelectList(_db.SubCategories, "SubcategoryId", "Name", product.SubcategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,Name,Description,Quantity,Active,Price,Picture,OldPrice,CategoryId,SubcategoryId,IsOutlet, Size, ProductCode")] Product product)
        {
            if (ModelState.IsValid)
            {
                var fileContent = Request.Files["Picture"];
                if (fileContent != null)
                {
                    var stream = fileContent.InputStream;
                    var fileName = Path.GetFileName(fileContent.FileName);
                    if (fileName != null)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            await stream.CopyToAsync(fileStream).ConfigureAwait(false);
                        }
                    }
                    product.Picture = $"~/Content/Images/{fileName}";
                    product.CreateDateTime = DateTime.Now;
                }
                _db.Entry(product).State = EntityState.Modified;
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", product.CategoryId);
            ViewBag.SubcategoryId = new SelectList(_db.SubCategories, "SubcategoryId", "Name", product.SubcategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = await _db.Products.FindAsync(id).ConfigureAwait(false);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var product = await _db.Products.FindAsync(id).ConfigureAwait(false);
            if (product != null) _db.Products.Remove(product);
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
