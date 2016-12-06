using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    //User: Huỳnh
    //TODO: CRUD Bài giảng, Xem phiên bản của file

    public class LessionController : Controller
    {
        // GET: Client/Lession
        public ActionResult Index()
        {
            ViewData["CSS"] = "lession";
            return View();
        }

        // GET: Client/Lession/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo bài giảng";
            ViewData["CSS"] = "create_lession";
            return View();
        }

        // GET: Client/Lession/Detail/1
        public ActionResult Detail(int id)
        {
            ViewData["CSS"] = "detail_lession";
            return View();
        }

        // GET: Client/Lession/Edit/1
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            ViewData["CSS"] = "create_lession";
            return View();
        }

        // GET: Client/Lession/Delete/1
        [Authorize(Roles = "Teacher")]
        public ActionResult Delete(int id)
        {
            ViewData["CSS"] = "default";
            return RedirectToAction("Index");
        }
    }
}