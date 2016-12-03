using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    //User: Huy
    //TODO: Xem danh sách phản hồi, xem chi tiết phản hồi từ người dùng

    [Authorize(Roles = "Client")]
    public class FeedbackController : Controller
    {
        // GET: Admin/Feedback
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Feedback/Detail/1
        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}