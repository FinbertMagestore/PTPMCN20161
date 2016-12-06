using Education.Areas.Admin.Model;
using Education.Areas.Admin.ModelsView;
using Education.Areas.Admin.Services;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    //User: Lộc
    //TODO: Xem danh sách báo cáo, xem chi tiết báo cáo

    [Authorize(Roles = "Admin")]
    public class ReportController : AdminBaseController
    {
        private ReportService reportService = new ReportService();
        private AccountService accountService = new AccountService();
        // GET: Admin/Report
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "system";
            ReportModel model = new ReportModel();
            model.Reports = reportService.GetAll();
            if (model.Reports != null && model.Reports.Count > 0)
            {
                foreach (var item in model.Reports)
                {
                    UpdateModel(item);
                }
            }
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
            //if (!string.IsNullOrEmpty(model.Keyword))
            //{
            //    where += string.Format(" and (Content like N'%{0}%') ",
            //        model.Keyword, model.Keyword, model.Keyword);
            //}
            if (!string.IsNullOrEmpty(model.Status))
            {
                where += string.Format(" and State = {0}", model.Status);
            }
            if (!string.IsNullOrEmpty(where))
            {
                where = where.Substring(4);
            }
            model.Reports = reportService.GetByWhere(where);
            if (model.Reports != null && model.Reports.Count > 0)
            {
                foreach (var item in model.Reports)
                {
                    UpdateModel(item);
                }
            }
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
                UpdateModel(report);
                return View(report);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(Report report)
        {
            string command = Request.Form["submit"].ToString();
            switch (command)
            {
                case "Delete":
                    return RedirectToAction("Delete", new { id = report.ID });
                case "Save":
                    report.State = true;
                    reportService.Update(report);
                    break;
                default:
                    break;
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Report/Delete/1
        public ActionResult Delete(int id)
        {
            Report report = reportService.GetByPrimaryKey(id);
            if (report != null)
            {
                UpdateModel(report);
                return View(report);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Delete(Report report)
        {
            reportService.DeleteByPrimaryKey(report.ID);
            if (!string.IsNullOrEmpty(report.ImageUrl))
            {
                string fileName = Server.MapPath(report.ImageUrl);
                if (System.IO.File.Exists(fileName))
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    Directory.Delete(fileInfo.Directory.FullName, true);
                }
            }
            return RedirectToAction("Index");
        }

        public void UpdateModel(Report item)
        {
            item.AppUser = accountService.GetByPrimaryKey(item.UserID);
            item.ReportType = reportService.GetReportType(item.ReportTypeID);
        }
    }
}