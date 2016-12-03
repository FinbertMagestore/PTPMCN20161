using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    //User: Huy
    // TODO CRUD Chuyên mục

    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Admin/Category/Detail/1
        public ActionResult Detail(int id)
        {
            return View();
        }

        // GET: Admin/Category/Edit/1
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: Admin/Category/Delete/1
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}