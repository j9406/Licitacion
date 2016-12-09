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
    public class LicitacionController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: Licitacion
        public async Task<ActionResult> Index()
        {
            var licitacion = db.Licitacion.Include(l => l.Licitador);
            return View(await licitacion.ToListAsync());
        }

        public async Task<ActionResult> Licitador( Int64 Id )
        {
            ViewBag.Id = Id;
            var licitacion = db.Licitacion.Where( l => l.LicitadorId == Id ).Include( l => l.Licitador );
            return View( await licitacion.ToListAsync() );
        }

        public ActionResult LicitadorCreate(Int64 Id)
        {
            ViewBag.LicitadorId = new SelectList( db.Licitador, "Id", "Nombre", Id );
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicitadorCreate( [Bind( Include = "Id,Nombre,LicitadorId,FechaCreacion,FechaCierre,FechaAdjudicacion,Observaciones" )] Licitacion licitacion )
        {
            if ( ModelState.IsValid ) {
                db.Licitacion.Add( licitacion );
                await db.SaveChangesAsync();
                return RedirectToAction( "Licitador", new { Id = licitacion.LicitadorId } );
            }

            ViewBag.LicitadorId = new SelectList( db.Licitador, "Id", "Nombre", licitacion.LicitadorId );
            return View( licitacion );
        }

        // GET: Licitacion/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitacion licitacion = await db.Licitacion.FindAsync(id);
            if (licitacion == null)
            {
                return HttpNotFound();
            }
            return View(licitacion);
        }

        // GET: Licitacion/Create
        public ActionResult Create()
        {
            ViewBag.LicitadorId = new SelectList(db.Licitador, "Id", "Nombre");
            return View();
        }

        // POST: Licitacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,LicitadorId,FechaCreacion,FechaCierre,FechaAdjudicacion,Observaciones")] Licitacion licitacion)
        {
            if (ModelState.IsValid)
            {
                db.Licitacion.Add(licitacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LicitadorId = new SelectList(db.Licitador, "Id", "Nombre", licitacion.LicitadorId);
            return View(licitacion);
        }

        // GET: Licitacion/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitacion licitacion = await db.Licitacion.FindAsync(id);
            if (licitacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicitadorId = new SelectList(db.Licitador, "Id", "Nombre", licitacion.LicitadorId);
            return View(licitacion);
        }

        // POST: Licitacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,LicitadorId,FechaCreacion,FechaCierre,FechaAdjudicacion,Observaciones")] Licitacion licitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LicitadorId = new SelectList(db.Licitador, "Id", "Nombre", licitacion.LicitadorId);
            return View(licitacion);
        }

        // GET: Licitacion/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitacion licitacion = await db.Licitacion.FindAsync(id);
            if (licitacion == null)
            {
                return HttpNotFound();
            }
            return View(licitacion);
        }

        // POST: Licitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Licitacion licitacion = await db.Licitacion.FindAsync(id);
            db.Licitacion.Remove(licitacion);
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
