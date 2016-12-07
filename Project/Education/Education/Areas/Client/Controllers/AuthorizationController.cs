using Education.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : BaseController
    {
        // GET: Client/Authorization
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Authorization", new { area = "Admin"});
        }

        // GET: Client/Authorization/Login
        public ActionResult Login()
        {
            CSS = "login";
            return RedirectToAction("Login", "Authorization", new { area = "Admin"});
            //return View();
        }

        // GET: Client/Authorization/Register
        public ActionResult Register()
        {
            CSS = "Register";
            return View();
        }
        // GET: Client/Authorization/DetailRegister
        public ActionResult DetailRegister()
        {
            CSS = "DetailRegister";
            return View();
        }

        // GET: Client/Authorization/Logout
        public ActionResult Logout()
        {
            return View();
        }
    }
}