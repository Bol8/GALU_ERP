using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GALU_ERP.Entidades;

namespace GALU_ERP.Controllers.Contactos
{
    public class contactosController : Controller
    {
        private GaluEntities db = new GaluEntities();

        // GET: contactos
        public async Task<ActionResult> Index()
        {
            return View(await db.contactoes.ToListAsync());
        }

        // GET: contactos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto contacto = await db.contactoes.FindAsync(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // GET: contactos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCONTACTO,Nombre,Origen,Producto")] contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.contactoes.Add(contacto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contacto);
        }

        // GET: contactos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto contacto = await db.contactoes.FindAsync(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: contactos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCONTACTO,Nombre,Origen,Producto,Telefono,Mail")] contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contacto);
        }

        // GET: contactos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto contacto = await db.contactoes.FindAsync(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            contacto contacto = await db.contactoes.FindAsync(id);
            db.contactoes.Remove(contacto);
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
