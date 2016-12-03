using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    [Authorize(Roles = "Client")]
    public class AccountController : Controller
    {
        // User: Huy
        // TODO: Danh sách người dùng, Trang cá nhân của người dùng, xem thông tin cơ bản, xem bài viết đã đăng, xem bài giảng đã đăng

        // GET: Client/Account
        public ActionResult Index()
        {
            ViewData["CSS"] = "default";
            return View();
        }
        // GET: Client/Account/Detail/1
        public ActionResult Detail(int id)
        {
            ViewData["CSS"] = "default";
            return View();
        }
        // GET: Client/Account/Edit/1
        public ActionResult Edit(int id)
        {
            ViewData["CSS"] = "default";
            return View();
        }
    }
}