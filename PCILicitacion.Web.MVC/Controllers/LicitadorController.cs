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
    public class LicitadorController : Controller
    {
        private EntidadDBContext db = new EntidadDBContext();

        // GET: Licitador
        public async Task<ActionResult> Index()
        {
            return View(await db.Licitador.ToListAsync());
        }

        // GET: Licitador/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitador licitador = await db.Licitador.FindAsync(id);
            if (licitador == null)
            {
                return HttpNotFound();
            }
            return View(licitador);
        }

        // GET: Licitador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Licitador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre")] Licitador licitador)
        {
            if (ModelState.IsValid)
            {
                db.Licitador.Add(licitador);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(licitador);
        }

        // GET: Licitador/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitador licitador = await db.Licitador.FindAsync(id);
            if (licitador == null)
            {
                return HttpNotFound();
            }
            return View(licitador);
        }

        // POST: Licitador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre")] Licitador licitador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitador).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(licitador);
        }

        // GET: Licitador/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitador licitador = await db.Licitador.FindAsync(id);
            if (licitador == null)
            {
                return HttpNotFound();
            }
            return View(licitador);
        }

        // POST: Licitador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Licitador licitador = await db.Licitador.FindAsync(id);
            db.Licitador.Remove(licitador);
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
