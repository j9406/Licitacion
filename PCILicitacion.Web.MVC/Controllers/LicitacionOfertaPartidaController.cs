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
    public class LicitacionOfertaPartidaController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();
        private PCILicitacionEntities entities = new PCILicitacionEntities();

        // GET: LicitacionOfertaPartida
        public async Task<ActionResult> Index()
        {
            var licitacionOfertaPartida = db.LicitacionOfertaPartida.Include(l => l.LicitacionOferta).Include(l => l.LicitacionPartida);
            return View(await licitacionOfertaPartida.ToListAsync());
        }

        // GET: LicitacionOfertaPartida
        public async Task<ActionResult> LicitacionOferta(Int64 Id)
        {
            ViewBag.Id = Id;
            var licitacionOfertaPartida = db.LicitacionOfertaPartida.Where(lop=> lop.LicitacionOfertaId == Id).Include(l => l.LicitacionOferta).Include(l => l.LicitacionPartida);
            return View(await licitacionOfertaPartida.ToListAsync());
        }

        // GET: LicitacionOfertaPartida/Create
        public async Task<ActionResult> LicitacionOfertaCreate(Int64 Id)
        {
            LicitacionOferta licitacionOferta = await db.LicitacionOferta.FindAsync(Id);
            ViewBag.LicitacionOfertaId = new SelectList(db.LicitacionOferta, "Id", "Id", Id);
            ViewBag.LicitacionPartidaId = new SelectList(entities.LicitacionPartidaView.Where(lpv=>lpv.LicitanteId == licitacionOferta.LicitanteId && lpv.LicitacionId == licitacionOferta.LicitacionId) , "LicitacionPartidaId", "LicitacionPartidaId");
            return View();
        }

        // POST: LicitacionOfertaPartida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicitacionOfertaCreate([Bind(Include = "Id,LicitacionOfertaId,LicitacionPartidaId")] LicitacionOfertaPartida licitacionOfertaPartida)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionOfertaPartida.Add(licitacionOfertaPartida);
                await db.SaveChangesAsync();
                return RedirectToAction("LicitacionOferta", new { Id = licitacionOfertaPartida.LicitacionOfertaId });
            }
            LicitacionOferta licitacionOferta = await db.LicitacionOferta.FindAsync(licitacionOfertaPartida.LicitacionOfertaId);
            ViewBag.LicitacionOfertaId = new SelectList(db.LicitacionOferta, "Id", "Id", licitacionOfertaPartida.LicitacionOfertaId);
            ViewBag.LicitacionPartidaId = new SelectList(entities.LicitacionPartidaView.Where(lpv => lpv.LicitanteId == licitacionOferta.LicitanteId && lpv.LicitacionId == licitacionOferta.LicitacionId), "LicitacionPartidaId", "LicitacionPartidaId");
            return View(licitacionOfertaPartida);
        }

        // GET: LicitacionOfertaPartida/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionOfertaPartida licitacionOfertaPartida = await db.LicitacionOfertaPartida.FindAsync(id);
            if (licitacionOfertaPartida == null)
            {
                return HttpNotFound();
            }
            return View(licitacionOfertaPartida);
        }

        // GET: LicitacionOfertaPartida/Create
        public ActionResult Create()
        {
            ViewBag.LicitacionOfertaId = new SelectList(db.LicitacionOferta, "Id", "Id");
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones");
            return View();
        }

        // POST: LicitacionOfertaPartida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LicitacionOfertaId,LicitacionPartidaId")] LicitacionOfertaPartida licitacionOfertaPartida)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionOfertaPartida.Add(licitacionOfertaPartida);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LicitacionOfertaId = new SelectList(db.LicitacionOferta, "Id", "Id", licitacionOfertaPartida.LicitacionOfertaId);
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionOfertaPartida.LicitacionPartidaId);
            return View(licitacionOfertaPartida);
        }

        // GET: LicitacionOfertaPartida/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionOfertaPartida licitacionOfertaPartida = await db.LicitacionOfertaPartida.FindAsync(id);
            if (licitacionOfertaPartida == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicitacionOfertaId = new SelectList(db.LicitacionOferta, "Id", "Id", licitacionOfertaPartida.LicitacionOfertaId);
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionOfertaPartida.LicitacionPartidaId);
            return View(licitacionOfertaPartida);
        }

        // POST: LicitacionOfertaPartida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LicitacionOfertaId,LicitacionPartidaId")] LicitacionOfertaPartida licitacionOfertaPartida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionOfertaPartida).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LicitacionOfertaId = new SelectList(db.LicitacionOferta, "Id", "Id", licitacionOfertaPartida.LicitacionOfertaId);
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionOfertaPartida.LicitacionPartidaId);
            return View(licitacionOfertaPartida);
        }

        // GET: LicitacionOfertaPartida/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionOfertaPartida licitacionOfertaPartida = await db.LicitacionOfertaPartida.FindAsync(id);
            if (licitacionOfertaPartida == null)
            {
                return HttpNotFound();
            }
            return View(licitacionOfertaPartida);
        }

        // POST: LicitacionOfertaPartida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitacionOfertaPartida licitacionOfertaPartida = await db.LicitacionOfertaPartida.FindAsync(id);
            db.LicitacionOfertaPartida.Remove(licitacionOfertaPartida);
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
