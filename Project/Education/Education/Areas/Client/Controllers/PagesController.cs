using Education.Areas.Admin.Controllers;
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
    public class PagesController : BaseController
    {
        // GET: Client/Pages
        public ActionResult Index()
        {
            return RedirectToAction("AboutUs");
        }

        // GET: Client/Pages/Policy
        public ActionResult Policy()
        {
            CSS = "default";
            return View();
        }

        // GET: Client/Pages/AboutUs
        public ActionResult AboutUs()
        {
            CSS = "default";
            return View();
        }

        // GET: Client/Pages/UserReview
        public ActionResult UserReview()
        {
            CSS = "default";
            return View();
        }

        // GET: Client/Pages/Document
        public ActionResult Documentation()
        {
            CSS = "default";
            return View();
        }
    }
}