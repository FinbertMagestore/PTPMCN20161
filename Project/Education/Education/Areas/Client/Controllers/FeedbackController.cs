using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    //User: Lộc 
    //TODO: Tạo phản hồi gửi về cho admin xem

    public class FeedbackController : Controller
    {
        // GET: Client/Feedback
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        // GET: Client/Feedback/Create
        public ActionResult Create()
        {
            ViewData["CSS"] = "createFeedback";
            return View();
        }
    }
}