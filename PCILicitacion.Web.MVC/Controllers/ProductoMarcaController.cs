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
    public class ProductoMarcaController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: ProductoMarca
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductoMarca.ToListAsync());
        }

        // GET: ProductoMarca/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoMarca productoMarca = await db.ProductoMarca.FindAsync(id);
            if (productoMarca == null)
            {
                return HttpNotFound();
            }
            return View(productoMarca);
        }

        // GET: ProductoMarca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoMarca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre")] ProductoMarca productoMarca)
        {
            if (ModelState.IsValid)
            {
                db.ProductoMarca.Add(productoMarca);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productoMarca);
        }

        // GET: ProductoMarca/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoMarca productoMarca = await db.ProductoMarca.FindAsync(id);
            if (productoMarca == null)
            {
                return HttpNotFound();
            }
            return View(productoMarca);
        }

        // POST: ProductoMarca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre")] ProductoMarca productoMarca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoMarca).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productoMarca);
        }

        // GET: ProductoMarca/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoMarca productoMarca = await db.ProductoMarca.FindAsync(id);
            if (productoMarca == null)
            {
                return HttpNotFound();
            }
            return View(productoMarca);
        }

        // POST: ProductoMarca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ProductoMarca productoMarca = await db.ProductoMarca.FindAsync(id);
            db.ProductoMarca.Remove(productoMarca);
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
