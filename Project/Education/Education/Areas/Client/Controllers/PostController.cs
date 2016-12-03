using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    //User: Huỳnh
    //TODO: CRUD bài viết ở phía client
    [AllowAnonymous]
    public class PostController : Controller
    {
        // GET: Client/Post
        public ActionResult Index()
        {
            ViewData["CSS"] = "default";
            return View();
        }

        // Note: không được tạo bài viết chỉ dành cho admin: trường ForAdminPost 
        // GET: Client/Post/1
        public ActionResult Create()
        {
            ViewData["CSS"] = "default";
            return View();
        }

        // GET: Client/Post/Detail/1
        public ActionResult Detail(int id)
        {
            ViewData["CSS"] = "default";
            return View();
        }

        // GET: Client/Post/Edit/1
        public ActionResult Edit(int id)
        {
            ViewData["CSS"] = "default";
            return View();
        }

        // GET: Client/Post/Delete/1
        public ActionResult Delete(int id)
        {
            ViewData["CSS"] = "default";
            return RedirectToAction("Index");
        }
    }
}