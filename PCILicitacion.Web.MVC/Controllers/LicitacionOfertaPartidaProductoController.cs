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
    public class LicitacionOfertaPartidaProductoController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();
        private PCILicitacionEntities entities = new PCILicitacionEntities();

        // GET: LicitacionOfertaPartidaProducto
        public async Task<ActionResult> Index()
        {
            var licitacionOfertaPartidaProducto = db.LicitacionOfertaPartidaProducto.Include(l => l.LicitacionOfertaPartida).Include(l => l.LicitacionPartidaProducto).Include(l => l.LicitacionPartidaProductoMarcas);
            return View(await licitacionOfertaPartidaProducto.ToListAsync());
        }

        public async Task<ActionResult> LicitacionOfertaPartida(Int64 Id)
        {
            ViewBag.Id = Id;
            var licitacionOfertaPartidaProducto = db.LicitacionOfertaPartidaProducto.Where(lopp => lopp.LicitacionOfertaPartidaId == Id).Include(l => l.LicitacionOfertaPartida).Include(l => l.LicitacionPartidaProducto).Include(l => l.LicitacionPartidaProductoMarcas);
            return View(await licitacionOfertaPartidaProducto.ToListAsync());
        }

        public async Task<ActionResult> LicitacionOfertaPartidaCreate(Int64 Id)
        {
            LicitacionOfertaPartida licitacionOfertaPartida = await db.LicitacionOfertaPartida.FindAsync(Id);
            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida.Where(lop => lop.LicitacionPartidaId == licitacionOfertaPartida.LicitacionPartidaId), "Id", "Id");
            ViewBag.LicitacionPartidaProductoId = new SelectList(entities.LicitacionPartidaProductoView.Where(lppv => lppv.LicitacionPartidaId == licitacionOfertaPartida.LicitacionPartidaId), "LicitacionPartidaProductoId", "LicitacionPartidaProductoId");
            ViewBag.LicitacionPartidaProductoMarcasId = new SelectList(entities.LicitacionPartidaProductoView.Where(lppv => lppv.LicitacionPartidaId == licitacionOfertaPartida.LicitacionPartidaId), "ProductoMarcaId", "ProductoMarcaId");
            return View();
        }

        // POST: LicitacionOfertaPartidaProducto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LicitacionOfertaPartidaCreate([Bind(Include = "Id,LicitacionOfertaPartidaId,LicitacionPartidaProductoMarcasId,LicitacionPartidaProductoId,PrecioUnitario")] LicitacionOfertaPartidaProducto licitacionOfertaPartidaProducto)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionOfertaPartidaProducto.Add(licitacionOfertaPartidaProducto);
                await db.SaveChangesAsync();
                return RedirectToAction("LicitacionOfertaPartida", new { Id = licitacionOfertaPartidaProducto.LicitacionOfertaPartidaId });
            }
            LicitacionOfertaPartida licitacionOfertaPartida = await db.LicitacionOfertaPartida.FindAsync(licitacionOfertaPartidaProducto.LicitacionOfertaPartidaId);
            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida.Where(lop => lop.LicitacionPartidaId == licitacionOfertaPartida.LicitacionPartidaId), "Id", "Id");
            ViewBag.LicitacionPartidaProductoId = new SelectList(entities.LicitacionPartidaProductoView.Where(lppv => lppv.LicitacionPartidaId == licitacionOfertaPartida.LicitacionPartidaId), "LicitacionPartidaProductoId", "LicitacionPartidaProductoId");
            ViewBag.LicitacionPartidaProductoMarcasId = new SelectList(entities.LicitacionPartidaProductoView.Where(lppv => lppv.LicitacionPartidaId == licitacionOfertaPartida.LicitacionPartidaId), "ProductoMarcaId", "ProductoMarcaId");
            return View(licitacionOfertaPartidaProducto);
        }


        // GET: LicitacionOfertaPartidaProducto/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionOfertaPartidaProducto licitacionOfertaPartidaProducto = await db.LicitacionOfertaPartidaProducto.FindAsync(id);
            if (licitacionOfertaPartidaProducto == null)
            {
                return HttpNotFound();
            }
            return View(licitacionOfertaPartidaProducto);
        }

        // GET: LicitacionOfertaPartidaProducto/Create
        public ActionResult Create()
        {
            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida, "Id", "Id");
            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones");
            ViewBag.LicitacionPartidaProductoMarcasId = new SelectList(db.LicitacionPartidaProductoMarcas, "Id", "Id");
            return View();
        }

        // POST: LicitacionOfertaPartidaProducto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LicitacionOfertaPartidaId,LicitacionPartidaProductoMarcasId,LicitacionPartidaProductoId,PrecioUnitario")] LicitacionOfertaPartidaProducto licitacionOfertaPartidaProducto)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionOfertaPartidaProducto.Add(licitacionOfertaPartidaProducto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida, "Id", "Id", licitacionOfertaPartidaProducto.LicitacionOfertaPartidaId);
            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones", licitacionOfertaPartidaProducto.LicitacionPartidaProductoId);
            ViewBag.LicitacionPartidaProductoMarcasId = new SelectList(db.LicitacionPartidaProductoMarcas, "Id", "Id", licitacionOfertaPartidaProducto.LicitacionPartidaProductoMarcasId);
            return View(licitacionOfertaPartidaProducto);
        }

        // GET: LicitacionOfertaPartidaProducto/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionOfertaPartidaProducto licitacionOfertaPartidaProducto = await db.LicitacionOfertaPartidaProducto.FindAsync(id);
            if (licitacionOfertaPartidaProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida, "Id", "Id", licitacionOfertaPartidaProducto.LicitacionOfertaPartidaId);
            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones", licitacionOfertaPartidaProducto.LicitacionPartidaProductoId);
            ViewBag.LicitacionPartidaProductoMarcasId = new SelectList(db.LicitacionPartidaProductoMarcas, "Id", "Id", licitacionOfertaPartidaProducto.LicitacionPartidaProductoMarcasId);
            return View(licitacionOfertaPartidaProducto);
        }

        // POST: LicitacionOfertaPartidaProducto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LicitacionOfertaPartidaId,LicitacionPartidaProductoMarcasId,LicitacionPartidaProductoId,PrecioUnitario")] LicitacionOfertaPartidaProducto licitacionOfertaPartidaProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionOfertaPartidaProducto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LicitacionOfertaPartidaId = new SelectList(db.LicitacionOfertaPartida, "Id", "Id", licitacionOfertaPartidaProducto.LicitacionOfertaPartidaId);
            ViewBag.LicitacionPartidaProductoId = new SelectList(db.LicitacionPartidaProducto, "Id", "Observaciones", licitacionOfertaPartidaProducto.LicitacionPartidaProductoId);
            ViewBag.LicitacionPartidaProductoMarcasId = new SelectList(db.LicitacionPartidaProductoMarcas, "Id", "Id", licitacionOfertaPartidaProducto.LicitacionPartidaProductoMarcasId);
            return View(licitacionOfertaPartidaProducto);
        }

        // GET: LicitacionOfertaPartidaProducto/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionOfertaPartidaProducto licitacionOfertaPartidaProducto = await db.LicitacionOfertaPartidaProducto.FindAsync(id);
            if (licitacionOfertaPartidaProducto == null)
            {
                return HttpNotFound();
            }
            return View(licitacionOfertaPartidaProducto);
        }

        // POST: LicitacionOfertaPartidaProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LicitacionOfertaPartidaProducto licitacionOfertaPartidaProducto = await db.LicitacionOfertaPartidaProducto.FindAsync(id);
            db.LicitacionOfertaPartidaProducto.Remove(licitacionOfertaPartidaProducto);
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
