using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    //User: Lộc
    //TODO: Xem danh sách báo cáo, xem chi tiết báo cáo

    [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        // GET: Admin/Report
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Report/Edit
        public ActionResult Edit()
        {
            return View();
        }
    }
}