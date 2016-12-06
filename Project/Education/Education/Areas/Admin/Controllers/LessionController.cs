using Education.Areas.Admin.Model;
using Education.Areas.Admin.ModelsView;
using Education.Areas.Admin.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LessionController : AdminBaseController
    {
        private LessionnService lessionService = new LessionnService();
        private TeacherService teacherService = new TeacherService();
        private AccountService accountService = new AccountService();
        // GET: Admin/Lessions
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "lession";
            LessionModel model = new LessionModel();
            model.Lessions = lessionService.GetAll();
            if (model.Lessions != null && model.Lessions.Count > 0)
            {
                foreach (var item in model.Lessions)
                {
                    UpdateModel(item);
                }
            }
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Bình thường", Value = "0" },
                new SelectListItem{ Text = " Đã khóa", Value = "1" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LessionModel model)
        {
            ViewData["CurrentMenu"] = "lession";
            string where = "";
            if (!string.IsNullOrEmpty(model.Keyword))
            {
                where += string.Format(" and (Name like N'%{0}%' or Description like N'%{1}%' or Alias like N'%{2}%') ",
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
            model.Lessions = lessionService.GetByWhere(where);
            if (model.Lessions != null && model.Lessions.Count > 0)
            {
                foreach (var item in model.Lessions)
                {
                    UpdateModel(item);
                }
            }
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Bình thường", Value = "0" },
                new SelectListItem{ Text = " Đã khóa", Value = "1" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        // GET: Admin/Lessions/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["CurrentMenu"] = "lession";
            Lession lession = lessionService.GetByPrimaryKey(id);
            UpdateModel(lession);
            if (lession != null)
            {
                return View(lession);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Lession lession)
        {
            string command = Request.Form["submit"].ToString();
            switch (command)
            {
                case "Delete":
                    return RedirectToAction("Delete", new { id = lession.ID });
                case "Block":
                    lession.Status = true;
                    lession.Modified = DateTime.Now;
                    lessionService.Update(lession);
                    break;
                case "Unblock":
                    lession.Status = false;
                    lession.Modified = DateTime.Now;
                    lessionService.Update(lession);
                    break;
                default:
                    break;
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Lessions/Delete/5
        public ActionResult Delete(int id)
        {
            Lession lession = lessionService.GetByPrimaryKey(id);
            UpdateModel(lession);
            return View(lession);
        }


        [HttpPost]
        public ActionResult Delete(Lession lession)
        {
            lessionService.DeleteByPrimaryKey(lession.ID);
            if (!String.IsNullOrEmpty(lession.ImageUrl))
            {
                string fileName = Server.MapPath(lession.ImageUrl);
                if (System.IO.File.Exists(fileName))
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    Directory.Delete(fileInfo.Directory.FullName, true);
                }
            }
            return RedirectToAction("Index");
        }

        private void UpdateModel(Lession lession)
        {
            lession.Teacher = teacherService.GetByPrimaryKey(lession.TeacherID);
            if (lession.Teacher != null)
            {
                lession.Teacher.AppUser = accountService.GetByPrimaryKey(lession.Teacher.UserID);
                lession.SubjectClass = lessionService.GetSubjectClass(lession.SubjectClassID);
                if (lession.SubjectClass != null)
                {
                    lession.Subject = lessionService.GetSubject(lession.SubjectClass.SubjectID);
                    lession.ClassInfo = lessionService.GetClassInfo(lession.SubjectClass.ClassInfoID);
                }
            }
        }
    }
}
