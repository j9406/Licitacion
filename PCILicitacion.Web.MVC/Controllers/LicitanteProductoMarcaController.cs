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
    public class LicitanteProductoMarcaController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: LicitanteProductoMarca
        public async Task<ActionResult> Index()
        {
            var licitanteProductoMarca = db.LicitanteProductoMarca.Include(l => l.Licitante).Include(l => l.Producto).Include(l => l.ProductoMarca);
            return View(await licitanteProductoMarca.ToListAsync());
        }
        public async Task<ActionResult> Licitante(Int64 Id)
        {
            ViewBag.Id = Id;
            var licitanteProductoMarca = db.LicitanteProductoMarca.Where(lpm=>lpm.LicitanteId==Id).Include( l => l.Licitante ).Include( l => l.Producto ).Include( l => l.ProductoMarca );
            return View( await licitanteProductoMarca.ToListAsync() );
        }

        public ActionResult LicitanteCreate(Int64 Id)
        {
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", Id);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", Id);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", Id);
            return View();
        }

        // POST: LicitanteProductoMarca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicitanteCreate([Bind(Include = "Id,LicitanteId,ProductoId,ProductoMarcaId")] LicitanteProductoMarca licitanteProductoMarca)
        {
            if (ModelState.IsValid)
            {
                db.LicitanteProductoMarca.Add(licitanteProductoMarca);
                await db.SaveChangesAsync();
                return RedirectToAction("Licitante", new { Id = licitanteProductoMarca.LicitanteId });
            }

            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", licitanteProductoMarca.LicitanteId);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", licitanteProductoMarca.ProductoId);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", licitanteProductoMarca.ProductoMarcaId);
            return View(licitanteProductoMarca);
        }


        // GET: LicitanteProductoMarca/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitanteProductoMarca licitanteProductoMarca = await db.LicitanteProductoMarca.FindAsync(id);
            if (licitanteProductoMarca == null)
            {
                return HttpNotFound();
            }
            return View(licitanteProductoMarca);
        }

        // GET: LicitanteProductoMarca/Create
        public ActionResult Create()
        {
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre");
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre");
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre");
            return View();
        }

        // POST: LicitanteProductoMarca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LicitanteId,ProductoId,ProductoMarcaId")] LicitanteProductoMarca licitanteProductoMarca)
        {
            if (ModelState.IsValid)
            {
                db.LicitanteProductoMarca.Add(licitanteProductoMarca);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", licitanteProductoMarca.LicitanteId);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", licitanteProductoMarca.ProductoId);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", licitanteProductoMarca.ProductoMarcaId);
            return View(licitanteProductoMarca);
        }

        // GET: LicitanteProductoMarca/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitanteProductoMarca licitanteProductoMarca = await db.LicitanteProductoMarca.FindAsync(id);
            if (licitanteProductoMarca == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", licitanteProductoMarca.LicitanteId);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", licitanteProductoMarca.ProductoId);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", licitanteProductoMarca.ProductoMarcaId);
            return View(licitanteProductoMarca);
        }

        // POST: LicitanteProductoMarca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LicitanteId,ProductoId,ProductoMarcaId")] LicitanteProductoMarca licitanteProductoMarca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitanteProductoMarca).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LicitanteId = new SelectList(db.Licitante, "Id", "Nombre", licitanteProductoMarca.LicitanteId);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", licitanteProductoMarca.ProductoId);
            ViewBag.ProductoMarcaId = new SelectList(db.ProductoMarca, "Id", "Nombre", licitanteProductoMarca.ProductoMarcaId);
            return View(licitanteProductoMarca);
        }

        // GET: LicitanteProductoMarca/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitanteProductoMarca licitanteProductoMarca = await db.LicitanteProductoMarca.FindAsync(id);
            if (licitanteProductoMarca == null)
            {
                return HttpNotFound();
            }
            return View(licitanteProductoMarca);
        }

        // POST: LicitanteProductoMarca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitanteProductoMarca licitanteProductoMarca = await db.LicitanteProductoMarca.FindAsync(id);
            db.LicitanteProductoMarca.Remove(licitanteProductoMarca);
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
