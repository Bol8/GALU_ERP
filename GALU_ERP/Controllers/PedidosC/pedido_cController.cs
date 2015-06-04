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

namespace GALU_ERP.Controllers.PedidosC
{
    public class pedido_cController : Controller
    {
        private GaluEntities db = new GaluEntities();

        // GET: pedido_c
        public async Task<ActionResult> Index()
        {
            ViewBag.idCliente = new SelectList(db.clientes, "idCli", "Razon_Social");
            ViewBag.Estado = new SelectList(db.estado_ped, "idEstados", "NombreE");
            ViewBag.Forma_pago = new SelectList(db.forma_pago, "idPAGO", "Tipo");
            var pedido_c = db.pedido_c.Include(p => p.cliente).Include(p => p.estado_ped).Include(p => p.forma_pago1);
            return View(await pedido_c.ToListAsync());
        }

        // GET: pedido_c/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido_c pedido_c = await db.pedido_c.FindAsync(id);
            if (pedido_c == null)
            {
                return HttpNotFound();
            }
            return View(pedido_c);
        }

        // GET: pedido_c/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.clientes, "idCli", "Razon_Social");
            ViewBag.Estado = new SelectList(db.estado_ped, "idEstados", "NombreE");
            ViewBag.Forma_pago = new SelectList(db.forma_pago, "idPAGO", "Tipo");
            return View();
        }

        // POST: pedido_c/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Num_ped,Fecha_A,Total,Destino,Tipo,Estado,Forma_pago,idCliente")] pedido_c pedido_c)
        {
            if (ModelState.IsValid)
            {
                db.pedido_c.Add(pedido_c);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.clientes, "idCli", "Razon_Social", pedido_c.idCliente);
            ViewBag.Estado = new SelectList(db.estado_ped, "idEstados", "NombreE", pedido_c.Estado);
            ViewBag.Forma_pago = new SelectList(db.forma_pago, "idPAGO", "Tipo", pedido_c.Forma_pago);

            return View(pedido_c);
        }

        // GET: pedido_c/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido_c pedido_c = await db.pedido_c.FindAsync(id);
            if (pedido_c == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.clientes, "idCli", "Razon_Social", pedido_c.idCliente);
            ViewBag.Estado = new SelectList(db.estado_ped, "idEstados", "NombreE", pedido_c.Estado);
            ViewBag.Forma_pago = new SelectList(db.forma_pago, "idPAGO", "Tipo", pedido_c.Forma_pago);
            return View(pedido_c);
        }

        // POST: pedido_c/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Num_ped,Fecha_A,Total,Destino,Tipo,Estado,Forma_pago,idCliente")] pedido_c pedido_c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido_c).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.clientes, "idCli", "Razon_Social", pedido_c.idCliente);
            ViewBag.Estado = new SelectList(db.estado_ped, "idEstados", "NombreE", pedido_c.Estado);
            ViewBag.Forma_pago = new SelectList(db.forma_pago, "idPAGO", "Tipo", pedido_c.Forma_pago);
            return View(pedido_c);
        }

        // GET: pedido_c/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido_c pedido_c = await db.pedido_c.FindAsync(id);
            if (pedido_c == null)
            {
                return HttpNotFound();
            }
            return View(pedido_c);
        }

        // POST: pedido_c/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            pedido_c pedido_c = await db.pedido_c.FindAsync(id);
            db.pedido_c.Remove(pedido_c);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> lineaPedido(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido_c pedido_c = await db.pedido_c.FindAsync(id);
            if (pedido_c == null)
            {
                return HttpNotFound();
            }

            ViewBag.lineas =  db.linea_pedido_c.Include(l => l.articulo).Include(l => l.pedido_c);
            ViewBag.idArticulo = new SelectList(db.articuloes, "idArt", "Nombre");
            ViewBag.Num_ped = new SelectList(db.pedido_c, "Num_ped", "Destino");

            return View(pedido_c);

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
