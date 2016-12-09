using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCILicitacion.Domain;

namespace PCILicitacion.Web.MVC.Controllers
{
    public class LicitanteLicitacionViewController : Controller
    {
        private PCILicitacionEntities db = new PCILicitacionEntities();

        // GET: LicitanteLicitacionView
        public async Task<ActionResult> Index()
        {
            return View(await db.LicitanteLicitacionView.ToListAsync());
        }

        public async Task<ActionResult> Licitante(Int64 Id)
        {
            return View( await db.LicitanteLicitacionView.Where( llv => llv.LicitanteId == Id ).OrderByDescending( llv => llv.LicitacionId ).ToListAsync() );
        }

        // GET: LicitanteLicitacionView/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitanteLicitacionView licitanteLicitacionView = await db.LicitanteLicitacionView.FindAsync(id);
            if (licitanteLicitacionView == null)
            {
                return HttpNotFound();
            }
            return View(licitanteLicitacionView);
        }

        // GET: LicitanteLicitacionView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LicitanteLicitacionView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LicitacionId,LicitacionNombre,LicitadorId,LicitadorNombre,FechaCreacion,FechaCierre,FechaAdjudicacion,Observaciones,LicitanteId,LicitanteNombre")] LicitanteLicitacionView licitanteLicitacionView)
        {
            if (ModelState.IsValid)
            {
                db.LicitanteLicitacionView.Add(licitanteLicitacionView);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(licitanteLicitacionView);
        }

        // GET: LicitanteLicitacionView/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitanteLicitacionView licitanteLicitacionView = await db.LicitanteLicitacionView.FindAsync(id);
            if (licitanteLicitacionView == null)
            {
                return HttpNotFound();
            }
            return View(licitanteLicitacionView);
        }

        // POST: LicitanteLicitacionView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LicitacionId,LicitacionNombre,LicitadorId,LicitadorNombre,FechaCreacion,FechaCierre,FechaAdjudicacion,Observaciones,LicitanteId,LicitanteNombre")] LicitanteLicitacionView licitanteLicitacionView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitanteLicitacionView).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(licitanteLicitacionView);
        }

        // GET: LicitanteLicitacionView/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitanteLicitacionView licitanteLicitacionView = await db.LicitanteLicitacionView.FindAsync(id);
            if (licitanteLicitacionView == null)
            {
                return HttpNotFound();
            }
            return View(licitanteLicitacionView);
        }

        // POST: LicitanteLicitacionView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitanteLicitacionView licitanteLicitacionView = await db.LicitanteLicitacionView.FindAsync(id);
            db.LicitanteLicitacionView.Remove(licitanteLicitacionView);
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
