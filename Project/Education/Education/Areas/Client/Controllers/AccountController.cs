using Education.Areas.Admin.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Education.Areas.Client.Controllers
{
     //[Authorize(Roles = "Client")]
    public class AccountController : Controller
    {
        // User: loctv
        // TODO: Danh sách người dùng, Trang cá nhân của người dùng, xem thông tin cơ bản, xem bài viết đã đăng, xem bài giảng đã đăng

        // GET: Client/Account
        public ActionResult Index()
        {
            return RedirectToAction("Detail", new { id = (int)Membership.GetUser(User.Identity.GetUserName()).ProviderUserKey });
        }
        // GET: Client/Account/Detail/1
        public ActionResult Detail(int id)
        {
            ViewData["CSS"] = "detail";
            AppUser model = new AppUser();
            return View(model);
        }
        // GET: Client/Account/Edit/1
        public ActionResult Edit(int id)
        {
            ViewData["CSS"] = "default";
            AppUser model = new AppUser();
            return View(model);
        }
        // GET: Client/Account/Posts/1
        public ActionResult Posts(int id)
        {
            ViewData["CSS"] = "posts";
            AppUser model = new AppUser();
            return View(model);
        }
        // GET: Client/Account/Lesson/1
        public ActionResult Lession(int id)
        {
            ViewData["CSS"] = "lesson";
            AppUser model = new AppUser();
            return View(model);
        }
    }
}