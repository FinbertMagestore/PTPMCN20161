using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    // User: Lộc
    // TODO: tạo các trang tĩnh ở footer
    [AllowAnonymous]
    public class PagesController : Controller
    {
        // GET: Client/Pages
        public ActionResult Index()
        {
            return RedirectToAction("AboutUs");
        }

        // GET: Client/Pages/Policy
        public ActionResult Policy()
        {
            ViewData["CSS"] = "default";
            return View();
        }

        // GET: Client/Pages/AboutUs
        public ActionResult AboutUs()
        {
            ViewData["CSS"] = "default";
            return View();
        }

        // GET: Client/Pages/UserReview
        public ActionResult UserReview()
        {
            ViewData["CSS"] = "default";
            return View();
        }

        // GET: Client/Pages/Document
        public ActionResult Documentation()
        {
            ViewData["CSS"] = "default";
            return View();
        }
    }
}