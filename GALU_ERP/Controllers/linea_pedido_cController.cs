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

namespace GALU_ERP.Controllers
{
    public class linea_pedido_cController : Controller
    {
        private GaluEntities db = new GaluEntities();

        // GET: linea_pedido_c
        public async Task<ActionResult> Index()
        {
            ViewBag.idArticulo = new SelectList(db.articuloes, "idArt", "Nombre");
            ViewBag.Num_ped = new SelectList(db.pedido_c, "Num_ped", "Destino");

            var linea_pedido_c = db.linea_pedido_c.Include(l => l.articulo).Include(l => l.pedido_c);

            return View(await linea_pedido_c.ToListAsync());
        }

        // GET: linea_pedido_c/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            linea_pedido_c linea_pedido_c = await db.linea_pedido_c.FindAsync(id);
            if (linea_pedido_c == null)
            {
                return HttpNotFound();
            }
            return View(linea_pedido_c);
        }

        // GET: linea_pedido_c/Create
        public ActionResult Create()
        {
            ViewBag.idArticulo = new SelectList(db.articuloes, "idArt", "Nombre");
            ViewBag.Num_ped = new SelectList(db.pedido_c, "Num_ped", "Destino");
            return View();
        }

        // POST: linea_pedido_c/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Linea,Num_ped,Cantidad,Total,idArticulo")] linea_pedido_c linea_pedido_c)
        {
            if (ModelState.IsValid)
            {
                db.linea_pedido_c.Add(linea_pedido_c);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idArticulo = new SelectList(db.articuloes, "idArt", "Nombre", linea_pedido_c.idArticulo);
            ViewBag.Num_ped = new SelectList(db.pedido_c, "Num_ped", "Destino", linea_pedido_c.Num_ped);
            return View(linea_pedido_c);
        }

        // GET: linea_pedido_c/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            linea_pedido_c linea_pedido_c = await db.linea_pedido_c.FindAsync(id);
            if (linea_pedido_c == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArticulo = new SelectList(db.articuloes, "idArt", "Nombre", linea_pedido_c.idArticulo);
            ViewBag.Num_ped = new SelectList(db.pedido_c, "Num_ped", "Destino", linea_pedido_c.Num_ped);
            return View(linea_pedido_c);
        }

        // POST: linea_pedido_c/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Linea,Num_ped,Cantidad,Total,idArticulo")] linea_pedido_c linea_pedido_c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linea_pedido_c).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idArticulo = new SelectList(db.articuloes, "idArt", "Nombre", linea_pedido_c.idArticulo);
            ViewBag.Num_ped = new SelectList(db.pedido_c, "Num_ped", "Destino", linea_pedido_c.Num_ped);
            return View(linea_pedido_c);
        }

        // GET: linea_pedido_c/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            linea_pedido_c linea_pedido_c = await db.linea_pedido_c.FindAsync(id);
            if (linea_pedido_c == null)
            {
                return HttpNotFound();
            }
            return View(linea_pedido_c);
        }

        // POST: linea_pedido_c/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            linea_pedido_c linea_pedido_c = await db.linea_pedido_c.FindAsync(id);
            db.linea_pedido_c.Remove(linea_pedido_c);
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
