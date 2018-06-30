using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Picaras.Model;
using Picaras.Model.Entities;

namespace PicarasMVC.Controllers
{
    public class AgentTransportsController : Controller
    {
        private PicarasModel db = new PicarasModel();

        // GET: AgentTransports
        public async Task<ActionResult> Index()
        {
            return View(await db.AgentTransports.ToListAsync());
        }

        // GET: AgentTransports/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgentTransport agentTransport = await db.AgentTransports.FindAsync(id);
            if (agentTransport == null)
            {
                return HttpNotFound();
            }
            return View(agentTransport);
        }

        // GET: AgentTransports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgentTransports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AgentTransportId,AgentName,Price")] AgentTransport agentTransport)
        {
            if (ModelState.IsValid)
            {
                db.AgentTransports.Add(agentTransport);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(agentTransport);
        }

        // GET: AgentTransports/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgentTransport agentTransport = await db.AgentTransports.FindAsync(id);
            if (agentTransport == null)
            {
                return HttpNotFound();
            }
            return View(agentTransport);
        }

        // POST: AgentTransports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AgentTransportId,AgentName,Price")] AgentTransport agentTransport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agentTransport).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(agentTransport);
        }

        // GET: AgentTransports/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgentTransport agentTransport = await db.AgentTransports.FindAsync(id);
            if (agentTransport == null)
            {
                return HttpNotFound();
            }
            return View(agentTransport);
        }

        // POST: AgentTransports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AgentTransport agentTransport = await db.AgentTransports.FindAsync(id);
            db.AgentTransports.Remove(agentTransport);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
