using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    //User: Huy
    // TODO: CRUD Post

    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        // GET: Admin/Post
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Admin/Post/Edit/1
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: Admin/Post/Delete/1
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}