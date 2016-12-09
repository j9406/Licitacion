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
    public class LicitacionPartidaProductoController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: LicitacionPartidaProducto
        public async Task<ActionResult> Index()
        {
            var licitacionPartidaProducto = db.LicitacionPartidaProducto.Include(l => l.LicitacionPartida).Include(l => l.Producto);
            return View(await licitacionPartidaProducto.ToListAsync());
        }

        public async Task<ActionResult> LicitacionPartida(Int64 Id)
        {
            ViewBag.Id = Id;
            var licitacionPartidaProducto = db.LicitacionPartidaProducto.Where(lpp => lpp.LicitacionPartidaId == Id).Include(l => l.LicitacionPartida).Include(l => l.Producto);
            return View(await licitacionPartidaProducto.ToListAsync());
        }

        // GET: LicitacionPartidaProducto/Create
        public ActionResult LicitacionPartidaCreate(Int64 Id)
        {
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", Id);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", Id);
            return View();
        }

        // POST: LicitacionPartidaProducto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicitacionPartidaCreate([Bind(Include = "Id,LicitacionPartidaId,ProductoId,Cantidad,Observaciones")] LicitacionPartidaProducto licitacionPartidaProducto)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionPartidaProducto.Add(licitacionPartidaProducto);
                await db.SaveChangesAsync();
                return RedirectToAction("LicitacionPartida", new { Id = licitacionPartidaProducto.LicitacionPartidaId });
            }

            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionPartidaProducto.LicitacionPartidaId);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", licitacionPartidaProducto.ProductoId);
            return View(licitacionPartidaProducto);
        }


        // GET: LicitacionPartidaProducto/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartidaProducto licitacionPartidaProducto = await db.LicitacionPartidaProducto.FindAsync(id);
            if (licitacionPartidaProducto == null)
            {
                return HttpNotFound();
            }
            return View(licitacionPartidaProducto);
        }


        // GET: LicitacionPartidaProducto/Create
        public ActionResult Create()
        {
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones");
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre");
            return View();
        }

        // POST: LicitacionPartidaProducto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LicitacionPartidaId,ProductoId,Cantidad,Observaciones")] LicitacionPartidaProducto licitacionPartidaProducto)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionPartidaProducto.Add(licitacionPartidaProducto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionPartidaProducto.LicitacionPartidaId);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", licitacionPartidaProducto.ProductoId);
            return View(licitacionPartidaProducto);
        }

        // GET: LicitacionPartidaProducto/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartidaProducto licitacionPartidaProducto = await db.LicitacionPartidaProducto.FindAsync(id);
            if (licitacionPartidaProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionPartidaProducto.LicitacionPartidaId);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", licitacionPartidaProducto.ProductoId);
            return View(licitacionPartidaProducto);
        }

        // POST: LicitacionPartidaProducto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LicitacionPartidaId,ProductoId,Cantidad,Observaciones")] LicitacionPartidaProducto licitacionPartidaProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionPartidaProducto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LicitacionPartidaId = new SelectList(db.LicitacionPartida, "Id", "Observaciones", licitacionPartidaProducto.LicitacionPartidaId);
            ViewBag.ProductoId = new SelectList(db.Producto, "Id", "Nombre", licitacionPartidaProducto.ProductoId);
            return View(licitacionPartidaProducto);
        }

        // GET: LicitacionPartidaProducto/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionPartidaProducto licitacionPartidaProducto = await db.LicitacionPartidaProducto.FindAsync(id);
            if (licitacionPartidaProducto == null)
            {
                return HttpNotFound();
            }
            return View(licitacionPartidaProducto);
        }

        // POST: LicitacionPartidaProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitacionPartidaProducto licitacionPartidaProducto = await db.LicitacionPartidaProducto.FindAsync(id);
            db.LicitacionPartidaProducto.Remove(licitacionPartidaProducto);
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
