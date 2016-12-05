using Education.Areas.Admin.Model;
using Education.Areas.Admin.ModelsView;
using Education.Areas.Admin.Services;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    //User: Huy
    //TODO: Xem danh sách phản hồi, xem chi tiết phản hồi từ người dùng

    [Authorize(Roles = "Admin")]
    public class FeedbackController : AdminBaseController
    {
        private FeedbackService feedbackService = new FeedbackService();
        // GET: Admin/Feedback
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "system";
            FeedbackModel model = new FeedbackModel();
            List<Feedback> feedbacks = feedbackService.GetAll();
            model.Feedbacks = feedbacks;
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Đã xử lý", Value = "1" },
                new SelectListItem{ Text = "Chưa xử lý", Value = "0" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FeedbackModel model)
        {
            ViewData["CurrentMenu"] = "system";
            string where = "";
            if (!string.IsNullOrEmpty(model.Keyword))
            {
                where += string.Format(" and (Name like N'%{0}%' or Email like N'%{1}%' or Content like N'%{2}%') ",
                    model.Keyword, model.Keyword, model.Keyword);
            }
            if (!string.IsNullOrEmpty(model.Status))
            {
                where += string.Format(" and State = {0}", model.Status);
            }
            if (!string.IsNullOrEmpty(where))
            {
                where = where.Substring(4);
            }
            List<Feedback> feedbacks = feedbackService.GetByWhere(where);
            model.Feedbacks = feedbacks;
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Đã xử lý", Value = "1" },
                new SelectListItem{ Text = "Chưa xử lý", Value = "0" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        // GET: Admin/Feedback/Edit/1
        public ActionResult Edit(int id)
        {
            ViewData["CurrentMenu"] = "system";
            Feedback feedback = feedbackService.GetByPrimaryKey(id);
            if (feedback != null)
            {
                return View(feedback);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(Feedback feedback)
        {
            string command = Request.Form["submit"].ToString();
            switch (command)
            {
                case "Delete":
                    return RedirectToAction("Delete", new { id = feedback.ID });
                case "Save":
                    feedback.State = true;
                    feedbackService.Update(feedback);
                    break;
                default:
                    break;
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Feedback/Delete/1
        public ActionResult Delete(int id)
        {
            Feedback feedback = feedbackService.GetByPrimaryKey(id);
            if (feedback != null)
            {
                return View(feedback);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Delete(Feedback feedback)
        {
            feedbackService.DeleteByPrimaryKey(feedback.ID);
            if (!string.IsNullOrEmpty(feedback.ImageUrl))
            {
                string fileName = Server.MapPath(feedback.ImageUrl);
                if (System.IO.File.Exists(fileName))
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    Directory.Delete(fileInfo.Directory.FullName, true);
                }
            }
            return RedirectToAction("Index");
        }
    }
}