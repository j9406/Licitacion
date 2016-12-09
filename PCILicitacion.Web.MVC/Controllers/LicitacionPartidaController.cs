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
    public class LicitacionPartidaController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: LicitacionPartida
        public async Task<ActionResult> Index()
        {
            var licitacionPartida = db.LicitacionPartida.Include(l => l.Licitacion);
            return View(await licitacionPartida.ToListAsync());
        }

        public async Task<ActionResult> Licitacion(Int64 Id)
        {
            ViewBag.Id = Id;
            var licitacionPartida = db.LicitacionPartida.Where(lp=>lp.LicitacionId== Id).Include(l => l.Licitacion);
            return View(await licitacionPartida.ToListAsync());
        }

        // GET: LicitacionPartida/Create
        public ActionResult LicitacionCreate(Int64 Id)
        {
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre", Id);
            return View();
        }

        // POST: LicitacionPartida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicitacionCreate([Bind(Include = "Id,LicitacionId,Observaciones")] LicitacionPartida licitacionPartida)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionPartida.Add(licitacionPartida);
                await db.SaveChangesAsync();
                return RedirectToAction("Licitacion", new { Id = licitacionPartida.LicitacionId });
            }

            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre", licitacionPartida.LicitacionId);
            return View(licitacionPartida);
        }


        // GET: LicitacionPartida/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartida licitacionPartida = await db.LicitacionPartida.FindAsync(id);
            if (licitacionPartida == null)
            {
                return HttpNotFound();
            }
            return View(licitacionPartida);
        }

        // GET: LicitacionPartida/Create
        public ActionResult Create()
        {
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre");
            return View();
        }

        // POST: LicitacionPartida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LicitacionId,Observaciones")] LicitacionPartida licitacionPartida)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionPartida.Add(licitacionPartida);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre", licitacionPartida.LicitacionId);
            return View(licitacionPartida);
        }

        // GET: LicitacionPartida/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartida licitacionPartida = await db.LicitacionPartida.FindAsync(id);
            if (licitacionPartida == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre", licitacionPartida.LicitacionId);
            return View(licitacionPartida);
        }

        // POST: LicitacionPartida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LicitacionId,Observaciones")] LicitacionPartida licitacionPartida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionPartida).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Nombre", licitacionPartida.LicitacionId);
            return View(licitacionPartida);
        }

        // GET: LicitacionPartida/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartida licitacionPartida = await db.LicitacionPartida.FindAsync(id);
            if (licitacionPartida == null)
            {
                return HttpNotFound();
            }
            return View(licitacionPartida);
        }

        // POST: LicitacionPartida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitacionPartida licitacionPartida = await db.LicitacionPartida.FindAsync(id);
            db.LicitacionPartida.Remove(licitacionPartida);
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
