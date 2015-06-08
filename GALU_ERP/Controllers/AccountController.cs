using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GALU_ERP.Models.Account;
using GALU_ERP.Models.User;
using GALU_ERP.Gestion;
using GALU_ERP.Security;




namespace GALU_ERP.Controllers
{

    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if(Membership.ValidateUser(model.userName, model.Password)){

                    FormsAuthentication.SetAuthCookie(model.userName, model.RememberMe);

                    return RedirectToAction("Index", "Home", null);

                }

            }


            return View(model);
        }


        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View("Register",null);
        }




        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel model)
        {

            if (ModelState.IsValid)
            {

                if (gUsers.SaveUser(model))
                {

                    return RedirectToAction("Login","Account");
                }
            }

            return View(model);
        }

    }
}