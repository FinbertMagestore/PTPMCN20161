using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        // GET: Client/Authorization
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        // GET: Client/Authorization/Login
        public ActionResult Login()
        {
            ViewData["CSS"] = "login";
            return View();
        }

        // GET: Client/Authorization/Register
        public ActionResult Register()
        {
            ViewData["CSS"] = "Register";
            return View();
        }
        // GET: Client/Authorization/DetailRegister
        public ActionResult DetailRegister()
        {
            ViewData["CSS"] = "DetailRegister";
            return View();
        }

        // GET: Client/Authorization/Logout
        public ActionResult Logout()
        {
            return View();
        }
    }
}