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

namespace GALU_ERP.Controllers.Productos
{
    public class articuloesController : Controller
    {
        private GaluEntities db = new GaluEntities();



        public ActionResult Presentacion()
        {



            return View();
        }


        // GET: articuloes
        public async Task<ActionResult> Index()
        {
            Console.WriteLine("Hola");
            var articuloes = db.articuloes.Include(a => a.estado1);
            return View(await articuloes.ToListAsync());
        }

        // GET: articuloes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = await db.articuloes.FindAsync(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: articuloes/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre");
            return View();
        }

        // POST: articuloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idArt,Nombre,Peso,Tipo,Estado,Precio,IVA,Descripcion,Origen,Imagen")] articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.articuloes.Add(articulo);
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    ViewBag.FailId = "Ese Código ya existe, introduzca otro";
                    ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre", articulo.Estado);
                    return View(articulo);
                }
               
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre", articulo.Estado);
            return View(articulo);
        }

        // GET: articuloes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = await db.articuloes.FindAsync(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre", articulo.Estado);
            return View(articulo);
        }

        // POST: articuloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idArt,Nombre,Peso,Tipo,Estado,Precio,IVA,Descripcion,Origen,Imagen")] articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre", articulo.Estado);
            return View(articulo);
        }

        // GET: articuloes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = await db.articuloes.FindAsync(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            articulo articulo = await db.articuloes.FindAsync(id);
            db.articuloes.Remove(articulo);
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
