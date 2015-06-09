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

namespace GALU_ERP.Controllers.Proveedores
{
    public class proveedoresController : Controller
    {
        private GaluEntities db = new GaluEntities();

        // GET: proveedores
        public async Task<ActionResult> Index()
        {
            var proveedors = db.proveedors.Include(p => p.estado1);
            return View(await proveedors.ToListAsync());
        }

        // GET: proveedores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = await db.proveedors.FindAsync(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: proveedores/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre");
            return View();
        }

        // POST: proveedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idProv,RazonSocial,NIF,NIF_R,Domicilio,CP,Poblacion,Provincia,Pais,Fecha_A,Estado,Imagen")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.proveedors.Add(proveedor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre", proveedor.Estado);
            return View(proveedor);
        }

        // GET: proveedores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = await db.proveedors.FindAsync(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre", proveedor.Estado);
            return View(proveedor);
        }

        // POST: proveedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idProv,RazonSocial,NIF,NIF_R,Domicilio,CP,Poblacion,Provincia,Pais,Fecha_A,Estado,Imagen")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre", proveedor.Estado);
            return View(proveedor);
        }

        // GET: proveedores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = await db.proveedors.FindAsync(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            proveedor proveedor = await db.proveedors.FindAsync(id);
            db.proveedors.Remove(proveedor);
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
