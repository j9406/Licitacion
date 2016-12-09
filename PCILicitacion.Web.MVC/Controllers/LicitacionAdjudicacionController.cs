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
using PCILicitacion.Model;

namespace PCILicitacion.Web.MVC.Controllers
{
    public class LicitacionAdjudicacionController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: LicitacionAdjudicacion
        public async Task<ActionResult> Index()
        {
            var licitacionAdjudicacion = db.LicitacionAdjudicacion.Include(l => l.Licitacion).Include(l => l.LicitacionOfertaPartida).Include(l => l.LicitacionPartida).Include(l => l.Licitante);
            return View(await licitacionAdjudicacion.ToListAsync());
        }

        // GET: LicitacionAdjudicacion/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionAdjudicacion licitacionAdjudicacion = await db.LicitacionAdjudicacion.FindAsync(id);
            if (licitacionAdjudicacion == null)
            {
                return HttpNotFound();
            }
            return View(licitacionAdjudicacion);
        }

        // GET: LicitacionAdjudicacion/Create
        public ActionResult Create()
        {
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre");
            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida, "Id", "Id");
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones");
            ViewBag.LicitanteId = new SelectList(db.Empresa, "Id", "Nombre");
            return View();
        }

        // POST: LicitacionAdjudicacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LicitacionId,LicitacionPartidaId,LicitanteId,LicitacionOfertaPartidaId")] LicitacionAdjudicacion licitacionAdjudicacion)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionAdjudicacion.Add(licitacionAdjudicacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre", licitacionAdjudicacion.LicitacionId);
            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida, "Id", "Id", licitacionAdjudicacion.LicitacionOfertaPartidaId);
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionAdjudicacion.LicitacionPartidaId);
            ViewBag.LicitanteId = new SelectList(db.Empresa, "Id", "Nombre", licitacionAdjudicacion.LicitanteId);
            return View(licitacionAdjudicacion);
        }

        // GET: LicitacionAdjudicacion/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionAdjudicacion licitacionAdjudicacion = await db.LicitacionAdjudicacion.FindAsync(id);
            if (licitacionAdjudicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre", licitacionAdjudicacion.LicitacionId);
            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida, "Id", "Id", licitacionAdjudicacion.LicitacionOfertaPartidaId);
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionAdjudicacion.LicitacionPartidaId);
            ViewBag.LicitanteId = new SelectList(db.Empresa, "Id", "Nombre", licitacionAdjudicacion.LicitanteId);
            return View(licitacionAdjudicacion);
        }

        // POST: LicitacionAdjudicacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LicitacionId,LicitacionPartidaId,LicitanteId,LicitacionOfertaPartidaId")] LicitacionAdjudicacion licitacionAdjudicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionAdjudicacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre", licitacionAdjudicacion.LicitacionId);
            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida, "Id", "Id", licitacionAdjudicacion.LicitacionOfertaPartidaId);
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionAdjudicacion.LicitacionPartidaId);
            ViewBag.LicitanteId = new SelectList(db.Empresa, "Id", "Nombre", licitacionAdjudicacion.LicitanteId);
            return View(licitacionAdjudicacion);
        }

        // GET: LicitacionAdjudicacion/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionAdjudicacion licitacionAdjudicacion = await db.LicitacionAdjudicacion.FindAsync(id);
            if (licitacionAdjudicacion == null)
            {
                return HttpNotFound();
            }
            return View(licitacionAdjudicacion);
        }

        // POST: LicitacionAdjudicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitacionAdjudicacion licitacionAdjudicacion = await db.LicitacionAdjudicacion.FindAsync(id);
            db.LicitacionAdjudicacion.Remove(licitacionAdjudicacion);
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
