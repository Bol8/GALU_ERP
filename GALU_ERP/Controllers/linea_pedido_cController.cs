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
using GALU_ERP.Collections;
using GALU_ERP.Models.ViewModel;

namespace GALU_ERP.Controllers
{
    public class linea_pedido_cController : Controller
    {
        private GaluEntities db = new GaluEntities();
        int i;


        public async Task<ActionResult> LineaPedido(int? id)
        {
           
            var lp = db.linea_pedido_c.Include(l => l.articulo).Include(l => l.pedido_c).Where(l => l.Num_ped == id);


            return View();
        }


        // GET: linea_pedido_c
        public async Task<ActionResult> Index(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}


            pedido_c pedido_c = await db.pedido_c.FindAsync(id);
            if (pedido_c == null)
            {
                return HttpNotFound();
            }


            ViewModel vm = new ViewModel();

            vm.pedido = pedido_c;
            vm.lineasPedido = db.linea_pedido_c.Include(l => l.articulo).Include(l => l.pedido_c).Where(l => l.Num_ped == pedido_c.Num_ped);

            var st = db.articuloes.ToList().Select(
                s => new
                {
                    idArt= s.idArt,
                    Nombre = s.Nombre + "   "+s.Peso+"gr."
                   
                });


            ViewBag.idArticulo = new SelectList(st, "idArt","Nombre");
            ViewBag.Num_ped = new SelectList(db.pedido_c, "Num_ped", "Destino");

           // var linea_pedido_c = db.linea_pedido_c.Include(l => l.articulo).Include(l => l.pedido_c);

            return View(vm);
        }

        // GET: linea_pedido_c/Details/5
        public async Task<ActionResult> Details(int? linea,int num_ped)
        {
           
            linea_pedido_c linea_pedido_c = await db.linea_pedido_c.FindAsync(linea,num_ped);

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
        public async Task<ActionResult> Create([Bind(Include = "Linea,Num_ped,Cantidad,Total,idArticulo,articulo")] linea_pedido_c linea_pedido_c)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if(db.linea_pedido_c.FindAsync(linea_pedido_c.Linea) != null)
                    {
                        linea_pedido_c.Linea = cLineaPedidos_C.getNumLine(linea_pedido_c.Num_ped);
                    }
                        articulo art = await db.articuloes.FindAsync(linea_pedido_c.idArticulo);
                        linea_pedido_c.Total = linea_pedido_c.Cantidad * art.Precio;
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            


                db.linea_pedido_c.Add(linea_pedido_c);
                await db.SaveChangesAsync();

                int i = linea_pedido_c.Num_ped;

                return RedirectToAction("Index", new { id = i});
            }



            ViewBag.idArticulo = new SelectList(db.articuloes, "idArt", "Nombre", linea_pedido_c.idArticulo);
            ViewBag.Num_ped = new SelectList(db.pedido_c, "Num_ped", "Destino", linea_pedido_c.Num_ped);


            return View(linea_pedido_c);
        }

        // GET: linea_pedido_c/Edit/5
        public async Task<ActionResult> Edit(int? linea, int num_ped)
        {
           
            linea_pedido_c linea_pedido_c = await db.linea_pedido_c.FindAsync(linea,num_ped);

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
        public async Task<ActionResult> Delete(int? linea, int num_ped)
        {
            
            linea_pedido_c linea_pedido_c = await db.linea_pedido_c.FindAsync(linea,num_ped);

            if (linea_pedido_c == null)
            {
                return HttpNotFound();
            
            }

            db.linea_pedido_c.Remove(linea_pedido_c);
            await db.SaveChangesAsync();

            var i = linea_pedido_c.Num_ped;

            return RedirectToAction("Index", new { id = i });
        }

        // POST: linea_pedido_c/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? linea, int num_ped)
        {
            linea_pedido_c linea_pedido_c = await db.linea_pedido_c.FindAsync(linea,num_ped);

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
