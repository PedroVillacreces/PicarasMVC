using System;
using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;

namespace PicarasMVC.Controllers
{
    [Authorize]
    public class AdminSlidersController : Controller
    {
        private readonly PicarasModel _db = new PicarasModel();

        // GET: AdminSliders
        public async Task<ActionResult> Index()
        {
            return View(await _db.AdminSlider.ToListAsync().ConfigureAwait(false));
        }

        // GET: AdminSliders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSlider = await _db.AdminSlider.FindAsync(id).ConfigureAwait(false);
            if (adminSlider == null)
            {
                return HttpNotFound();
            }
            return View(adminSlider);
        }

        // GET: AdminSliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminSliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AdminSliderId,Image,Title,Description")] AdminSlider adminSlider)
        {
            if (ModelState.IsValid)
            {
                var fileContent = Request.Files["Image"];
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
                    adminSlider.Image = $"~/Content/Images/Slider/{fileName}";
                }
                _db.AdminSlider.Add(adminSlider);
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Index");
            }

            return View(adminSlider);
        }

        // GET: AdminSliders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSlider = await _db.AdminSlider.FindAsync(id).ConfigureAwait(false);
            if (adminSlider == null)
            {
                return HttpNotFound();
            }
            return View(adminSlider);
        }

        // POST: AdminSliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AdminSliderId,Image,Title,Description")] AdminSlider adminSlider)
        {
            if (!ModelState.IsValid) return View(adminSlider);
            _db.Entry(adminSlider).State = EntityState.Modified;
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: AdminSliders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adminSlider = await _db.AdminSlider.FindAsync(id).ConfigureAwait(false);
            if (adminSlider == null)
            {
                return HttpNotFound();
            }
            return View(adminSlider);
        }

        // POST: AdminSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var adminSlider = await _db.AdminSlider.FindAsync(id).ConfigureAwait(false);
            if (adminSlider != null) _db.AdminSlider.Remove(adminSlider);
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
