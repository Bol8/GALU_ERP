using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GALU_ERP.Models.Account;




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
    }
}