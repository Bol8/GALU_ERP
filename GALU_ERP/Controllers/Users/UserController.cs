using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GALU_ERP.Models.User;
using System.Net;
using GALU_ERP.Entidades;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Security;

namespace GALU_ERP.Controllers.Users
{
    public class UserController : Controller
    {
        private GaluEntities db = new GaluEntities();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel model)
        {

            if (ModelState.IsValid)
            {



            }

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario user = await db.usuarios.FindAsync(id);

            if (user == null)
            {
                return HttpNotFound();
            }


            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit ([Bind(Include="id,Nombre,apellidos,email,telefono,Rol,userName,Password,imagen")] usuario user )
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();

                FormsAuthentication.Initialize();
                FormsAuthentication.SetAuthCookie(user.UserName, false);

                return RedirectToAction("Index","Home");
            }
           // ViewBag.Estado = new SelectList(db.estados, "idESTADOS", "Nombre", cliente.Estado);
           
            
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
