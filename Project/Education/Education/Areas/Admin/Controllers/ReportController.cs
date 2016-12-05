using Education.Areas.Admin.Model;
using Education.Areas.Admin.ModelsView;
using Education.Areas.Admin.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    //User: Lộc
    //TODO: Xem danh sách báo cáo, xem chi tiết báo cáo

    [Authorize(Roles = "Admin")]
    public class ReportController : AdminBaseController
    {
        private ReportService reportService = new ReportService();
        // GET: Admin/Report
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "system";
            ReportModel model = new ReportModel();
            model.Reports = reportService.GetAll();
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Đã xử lý", Value = "1" },
                new SelectListItem{ Text = "Chưa xử lý", Value = "0" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ReportModel model)
        {
            ViewData["CurrentMenu"] = "system";
            string where = "";
            if (!string.IsNullOrEmpty(model.Keyword))
            {
                where += string.Format(" and (Content like N'%{0}%') ",
                    model.Keyword, model.Keyword, model.Keyword);
            }
            if (!string.IsNullOrEmpty(model.Status))
            {
                where += string.Format(" and Status = {0}", model.Status);
            }
            if (!string.IsNullOrEmpty(where))
            {
                where = where.Substring(4);
            }
            model.Reports = reportService.GetByWhere(where);
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Đã xử lý", Value = "1" },
                new SelectListItem{ Text = "Chưa xử lý", Value = "0" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        // GET: Admin/Report/Edit/1
        public ActionResult Edit(int id)
        {
            ViewData["CurrentMenu"] = "system";
            Report report = reportService.GetByPrimaryKey(id);
            if (report != null)
            {
                return View(report);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}