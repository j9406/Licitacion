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
    public class LicitanteController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: Licitante
        public async Task<ActionResult> Index()
        {
            return View(await db.Licitante.ToListAsync());
        }



        // GET: Licitante/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitante licitante = await db.Licitante.FindAsync(id);
            if (licitante == null)
            {
                return HttpNotFound();
            }
            return View(licitante);
        }

        // GET: Licitante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Licitante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre")] Licitante licitante)
        {
            if (ModelState.IsValid)
            {
                db.Licitante.Add(licitante);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(licitante);
        }

        // GET: Licitante/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitante licitante = await db.Licitante.FindAsync(id);
            if (licitante == null)
            {
                return HttpNotFound();
            }
            return View(licitante);
        }

        // POST: Licitante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre")] Licitante licitante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitante).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(licitante);
        }

        // GET: Licitante/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitante licitante = await db.Licitante.FindAsync(id);
            if (licitante == null)
            {
                return HttpNotFound();
            }
            return View(licitante);
        }

        // POST: Licitante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Licitante licitante = await db.Licitante.FindAsync(id);
            db.Licitante.Remove(licitante);
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
