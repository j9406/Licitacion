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
    public class LicitacionPartidaProductoViewController : Controller
    {
        private PCILicitacionEntities db = new PCILicitacionEntities();

        // GET: LicitacionPartidaProductoView
        public async Task<ActionResult> Index()
        {
            return View(await db.LicitacionPartidaProductoView.ToListAsync());
        }

        // GET: LicitacionPartidaProductoView/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartidaProductoView licitacionPartidaProductoView = await db.LicitacionPartidaProductoView.FindAsync(id);
            if (licitacionPartidaProductoView == null)
            {
                return HttpNotFound();
            }
            return View(licitacionPartidaProductoView);
        }

        // GET: LicitacionPartidaProductoView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LicitacionPartidaProductoView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LicitanteId,Licitante,LicitadorId,Licitador,LicitacionId,LicitacionPartidaId,LicitacionPartidaProductoId,ProductoId,ProductoNombre,ProductoCantidad,ProductoObservaciones,ProductoMarcaId,ProductoMarca")] LicitacionPartidaProductoView licitacionPartidaProductoView)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionPartidaProductoView.Add(licitacionPartidaProductoView);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(licitacionPartidaProductoView);
        }

        // GET: LicitacionPartidaProductoView/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartidaProductoView licitacionPartidaProductoView = await db.LicitacionPartidaProductoView.FindAsync(id);
            if (licitacionPartidaProductoView == null)
            {
                return HttpNotFound();
            }
            return View(licitacionPartidaProductoView);
        }

        // POST: LicitacionPartidaProductoView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LicitanteId,Licitante,LicitadorId,Licitador,LicitacionId,LicitacionPartidaId,LicitacionPartidaProductoId,ProductoId,ProductoNombre,ProductoCantidad,ProductoObservaciones,ProductoMarcaId,ProductoMarca")] LicitacionPartidaProductoView licitacionPartidaProductoView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionPartidaProductoView).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(licitacionPartidaProductoView);
        }

        // GET: LicitacionPartidaProductoView/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartidaProductoView licitacionPartidaProductoView = await db.LicitacionPartidaProductoView.FindAsync(id);
            if (licitacionPartidaProductoView == null)
            {
                return HttpNotFound();
            }
            return View(licitacionPartidaProductoView);
        }

        // POST: LicitacionPartidaProductoView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitacionPartidaProductoView licitacionPartidaProductoView = await db.LicitacionPartidaProductoView.FindAsync(id);
            db.LicitacionPartidaProductoView.Remove(licitacionPartidaProductoView);
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
