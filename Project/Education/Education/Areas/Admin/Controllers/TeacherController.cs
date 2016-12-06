using Education.Areas.Admin.Model;
using Education.Areas.Admin.ModelsView;
using Education.Areas.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    public class TeacherController : AdminBaseController
    {
        private TeacherService teacherService = new TeacherService();
        private SubjectService subjectService = new SubjectService();
        private AccountService accountService = new AccountService();
        private SchoolService schoolService = new SchoolService();

        // GET: Admin/Teacher
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "education";
            TeacherModel model = new TeacherModel();
            model.Teachers = teacherService.GetAll();
            if (model.Teachers != null && model.Teachers.Count > 0)
            {
                foreach (var item in model.Teachers)
                {
                    UpdateModel(item);
                }
            }
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Hiển thị", Value = "1" },
                new SelectListItem{ Text = "Ẩn", Value = "0" }
            }, "Value", "Text", model.Status);
            return View(model);
        }


        public void UpdateModel(Teacher teacher)
        {
            teacher.Subject = subjectService.GetByPrimaryKey(teacher.MainSubjectID);
            teacher.AppUser = accountService.GetByPrimaryKey(teacher.UserID);
            if (teacher.SchoolID.HasValue)
            {
                teacher.SchoolName = schoolService.GetByPrimaryKey(teacher.SchoolID.Value).Name;
            }
        }
    }
}