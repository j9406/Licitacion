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
    public class LicitacionPartidaProductoMarcasController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: LicitacionPartidaProductoMarcas
        public async Task<ActionResult> Index()
        {
            var licitacionPartidaProductoMarcas = db.LicitacionPartidaProductoMarcas.Include(l => l.LicitacionPartidaProducto).Include(l => l.ProductoMarca);
            return View(await licitacionPartidaProductoMarcas.ToListAsync());
        }

        public async Task<ActionResult> LicitacionPartidaProducto(Int64 Id)
        {
            ViewBag.Id = Id;
            var licitacionPartidaProductoMarcas = db.LicitacionPartidaProductoMarcas.Where(lppm => lppm.LicitacionPartidaProductoId == Id).Include(l => l.LicitacionPartidaProducto).Include(l => l.ProductoMarca);
            return View(await licitacionPartidaProductoMarcas.ToListAsync());
        }

        public ActionResult LicitacionPartidaProductoCreate(Int64 Id)
        {
            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones", Id);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", Id);
            return View();
        }

        // POST: LicitacionPartidaProductoMarcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicitacionPartidaProductoCreate([Bind(Include = "Id,LicitacionPartidaProductoId,ProductoMarcaId")] LicitacionPartidaProductoMarcas licitacionPartidaProductoMarcas)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionPartidaProductoMarcas.Add(licitacionPartidaProductoMarcas);
                await db.SaveChangesAsync();
                return RedirectToAction("LicitacionPartidaProducto", new { Id = licitacionPartidaProductoMarcas.LicitacionPartidaProductoId });
            }

            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones", licitacionPartidaProductoMarcas.LicitacionPartidaProductoId);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", licitacionPartidaProductoMarcas.ProductoMarcaId);
            return View(licitacionPartidaProductoMarcas);
        }

        // GET: LicitacionPartidaProductoMarcas/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartidaProductoMarcas licitacionPartidaProductoMarcas = await db.LicitacionPartidaProductoMarcas.FindAsync(id);
            if (licitacionPartidaProductoMarcas == null)
            {
                return HttpNotFound();
            }
            return View(licitacionPartidaProductoMarcas);
        }


        // GET: LicitacionPartidaProductoMarcas/Create
        public ActionResult Create()
        {
            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones");
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre");
            return View();
        }

        // POST: LicitacionPartidaProductoMarcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LicitacionPartidaProductoId,ProductoMarcaId")] LicitacionPartidaProductoMarcas licitacionPartidaProductoMarcas)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionPartidaProductoMarcas.Add(licitacionPartidaProductoMarcas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones", licitacionPartidaProductoMarcas.LicitacionPartidaProductoId);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", licitacionPartidaProductoMarcas.ProductoMarcaId);
            return View(licitacionPartidaProductoMarcas);
        }

        // GET: LicitacionPartidaProductoMarcas/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartidaProductoMarcas licitacionPartidaProductoMarcas = await db.LicitacionPartidaProductoMarcas.FindAsync(id);
            if (licitacionPartidaProductoMarcas == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones", licitacionPartidaProductoMarcas.LicitacionPartidaProductoId);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", licitacionPartidaProductoMarcas.ProductoMarcaId);
            return View(licitacionPartidaProductoMarcas);
        }

        // POST: LicitacionPartidaProductoMarcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LicitacionPartidaProductoId,ProductoMarcaId")] LicitacionPartidaProductoMarcas licitacionPartidaProductoMarcas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionPartidaProductoMarcas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones", licitacionPartidaProductoMarcas.LicitacionPartidaProductoId);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", licitacionPartidaProductoMarcas.ProductoMarcaId);
            return View(licitacionPartidaProductoMarcas);
        }

        // GET: LicitacionPartidaProductoMarcas/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartidaProductoMarcas licitacionPartidaProductoMarcas = await db.LicitacionPartidaProductoMarcas.FindAsync(id);
            if (licitacionPartidaProductoMarcas == null)
            {
                return HttpNotFound();
            }
            return View(licitacionPartidaProductoMarcas);
        }

        // POST: LicitacionPartidaProductoMarcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitacionPartidaProductoMarcas licitacionPartidaProductoMarcas = await db.LicitacionPartidaProductoMarcas.FindAsync(id);
            db.LicitacionPartidaProductoMarcas.Remove(licitacionPartidaProductoMarcas);
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
