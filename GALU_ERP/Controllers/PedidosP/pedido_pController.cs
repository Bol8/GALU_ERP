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

namespace GALU_ERP.Controllers.PedidosP
{
    public class pedido_pController : Controller
    {
        private GaluEntities db = new GaluEntities();

        // GET: pedido_p
        public async Task<ActionResult> Index()
        {
            var pedido_p = db.pedido_p.Include(p => p.estado_ped).Include(p => p.forma_pago1).Include(p => p.proveedor);
            return View(await pedido_p.ToListAsync());
        }

        // GET: pedido_p/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido_p pedido_p = await db.pedido_p.FindAsync(id);
            if (pedido_p == null)
            {
                return HttpNotFound();
            }
            return View(pedido_p);
        }

        // GET: pedido_p/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.estado_ped, "idEstados", "NombreE");
            ViewBag.Forma_pago = new SelectList(db.forma_pago, "idPAGO", "Tipo");
            ViewBag.idProv = new SelectList(db.proveedors, "idProv", "RazonSocial");
            return View();
        }

        // POST: pedido_p/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Num_ped,Fecha_A,Total,Tipo,Estado,Forma_pago,idProv")] pedido_p pedido_p)
        {
            if (ModelState.IsValid)
            {
                db.pedido_p.Add(pedido_p);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.estado_ped, "idEstados", "NombreE", pedido_p.Estado);
            ViewBag.Forma_pago = new SelectList(db.forma_pago, "idPAGO", "Tipo", pedido_p.Forma_pago);
            ViewBag.idProv = new SelectList(db.proveedors, "idProv", "RazonSocial", pedido_p.idProv);
            return View(pedido_p);
        }

        // GET: pedido_p/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido_p pedido_p = await db.pedido_p.FindAsync(id);
            if (pedido_p == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.estado_ped, "idEstados", "NombreE", pedido_p.Estado);
            ViewBag.Forma_pago = new SelectList(db.forma_pago, "idPAGO", "Tipo", pedido_p.Forma_pago);
            ViewBag.idProv = new SelectList(db.proveedors, "idProv", "RazonSocial", pedido_p.idProv);
            return View(pedido_p);
        }

        // POST: pedido_p/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Num_ped,Fecha_A,Total,Tipo,Estado,Forma_pago,idProv")] pedido_p pedido_p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido_p).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.estado_ped, "idEstados", "NombreE", pedido_p.Estado);
            ViewBag.Forma_pago = new SelectList(db.forma_pago, "idPAGO", "Tipo", pedido_p.Forma_pago);
            ViewBag.idProv = new SelectList(db.proveedors, "idProv", "RazonSocial", pedido_p.idProv);
            return View(pedido_p);
        }

        // GET: pedido_p/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido_p pedido_p = await db.pedido_p.FindAsync(id);
            if (pedido_p == null)
            {
                return HttpNotFound();
            }
            return View(pedido_p);
        }

        // POST: pedido_p/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            pedido_p pedido_p = await db.pedido_p.FindAsync(id);
            db.pedido_p.Remove(pedido_p);
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
