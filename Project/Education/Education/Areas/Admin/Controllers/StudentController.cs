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
    public class StudentController : AdminBaseController
    {
        private AccountService accountService = new AccountService();
        private StudentService studentService = new StudentService();
        private ClassInfoService classInfoService = new ClassInfoService();
        private SchoolService schoolService = new SchoolService();

        // GET: Admin/Student
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "education";
            StudentModel model = new StudentModel();
            model.Students = studentService.GetAll();
            if (model.Students != null && model.Students.Count > 0)
            {
                foreach (var item in model.Students)
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

        public void UpdateModel(Student student)
        {
            student.AppUser = accountService.GetByPrimaryKey(student.UserID);
            student.ClassInfo = classInfoService.GetByPrimaryKey(student.ClassInfoID);
            if (student.SchoolID.HasValue)
            {
                student.SchoolName = schoolService.GetByPrimaryKey(student.SchoolID.Value).Name;
            }
        }
    }
}