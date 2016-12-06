using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Client/Category
        public ActionResult Index()
        {
            ViewData["CSS"] = "category";
            return View();
        }

        // GET: Client/Category/Detail
        public ActionResult Detail(int id)
        {
            ViewData["CSS"] = "default";
            return View();
        }
    }
}