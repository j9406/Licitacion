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
    public class LicitacionOfertaController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: LicitacionOferta
        public async Task<ActionResult> Index()
        {
            var licitacionOferta = db.LicitacionOferta.Include(l => l.Licitacion).Include(l => l.Licitante);
            return View(await licitacionOferta.ToListAsync());
        }

        public async Task<ActionResult> LicitacionLicitante( Int64 LicitacionId, Int64 LicitanteId )
        {
            ViewBag.LicitacionId = LicitacionId;
            ViewBag.LicitanteId = LicitanteId;
            var licitacionOferta = db.LicitacionOferta.Where( lo => lo.LicitacionId == LicitacionId && lo.LicitanteId == LicitanteId ).Include( l => l.Licitacion ).Include( l => l.Licitante );
            return View( await licitacionOferta.ToListAsync() );
        }

        public async Task<ActionResult> Licitante(Int64 Id)
        {
            ViewBag.Id = Id;
            var licitacionOferta = db.LicitacionOferta.Where(lo=>lo.LicitanteId==Id).Include( l => l.Licitacion ).Include( l => l.Licitante );
            return View( await licitacionOferta.ToListAsync() );
        }

        public ActionResult LicitanteCreate(Int64 Id)
        {
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Id", Id);
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", Id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicitanteCreate([Bind(Include = "Id,LicitacionId,LicitanteId,FechaOferta,FechaVigencia")] LicitacionOferta licitacionOferta)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionOferta.Add(licitacionOferta);
                await db.SaveChangesAsync();
                return RedirectToAction("Licitante", new { Id = licitacionOferta.LicitanteId });
            }

            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Id", licitacionOferta.LicitacionId);
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", licitacionOferta.LicitanteId);
            return View(licitacionOferta);
        }

        // GET: LicitacionOferta/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionOferta licitacionOferta = await db.LicitacionOferta.FindAsync(id);
            if (licitacionOferta == null)
            {
                return HttpNotFound();
            }
            return View(licitacionOferta);
        }

        // GET: LicitacionOferta/Create
        public ActionResult Create()
        {
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Id");
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre");
            return View();
        }

        public ActionResult LicitacionLicitanteCreate( Int64 LicitacionId, Int64 LicitanteId )
        {
            ViewBag.LicitacionId = new SelectList( db.Licitacion, "Id", "Id", LicitacionId );
            ViewBag.LicitanteId = new SelectList( db.Licitante, "Id", "Nombre", LicitanteId );
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicitacionLicitanteCreate( [Bind( Include = "Id,LicitacionId,LicitanteId,FechaOferta,FechaVigencia" )] LicitacionOferta licitacionOferta )
        {
            if ( ModelState.IsValid ) {
                db.LicitacionOferta.Add( licitacionOferta );
                await db.SaveChangesAsync();
                return RedirectToAction( "LicitacionLicitante", new { LicitacionId = licitacionOferta.LicitacionId, LicitanteID = licitacionOferta.LicitanteId } );
            }
            ViewBag.LicitacionId = new SelectList( db.Licitacion, "Id", "Id", licitacionOferta.LicitacionId );
            ViewBag.LicitanteId = new SelectList( db.Licitante, "Id", "Nombre", licitacionOferta.LicitanteId );
            return View( licitacionOferta );
        }

        // POST: LicitacionOferta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LicitacionId,LicitanteId,FechaOferta,FechaVigencia")] LicitacionOferta licitacionOferta)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionOferta.Add(licitacionOferta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Id", licitacionOferta.LicitacionId);
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", licitacionOferta.LicitanteId);
            return View(licitacionOferta);
        }

        // GET: LicitacionOferta/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionOferta licitacionOferta = await db.LicitacionOferta.FindAsync(id);
            if (licitacionOferta == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Id", licitacionOferta.LicitacionId);
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", licitacionOferta.LicitanteId);
            return View(licitacionOferta);
        }

        // POST: LicitacionOferta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LicitacionId,LicitanteId,FechaOferta,FechaVigencia")] LicitacionOferta licitacionOferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionOferta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LicitacionId = new SelectList(db.Licitacion, "Id", "Id", licitacionOferta.LicitacionId);
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", licitacionOferta.LicitanteId);
            return View(licitacionOferta);
        }

        // GET: LicitacionOferta/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionOferta licitacionOferta = await db.LicitacionOferta.FindAsync(id);
            if (licitacionOferta == null)
            {
                return HttpNotFound();
            }
            return View(licitacionOferta);
        }

        // POST: LicitacionOferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitacionOferta licitacionOferta = await db.LicitacionOferta.FindAsync(id);
            db.LicitacionOferta.Remove(licitacionOferta);
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
