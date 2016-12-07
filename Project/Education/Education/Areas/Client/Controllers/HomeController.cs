using Education.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Client/Home
        public ActionResult Index()
        {
            CSS = "default";
            return View();
        }
    }
}