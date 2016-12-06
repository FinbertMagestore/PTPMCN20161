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
    public class SchoolController : AdminBaseController
    {
        private SchoolService schoolService = new SchoolService();
        private SchoolTypeService schoolTypeService = new SchoolTypeService();
        private LevelEducationService levelEducationService = new LevelEducationService();

        // GET: Admin/School
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "education";
            SchoolModel model = new SchoolModel();
            model.Schools = schoolService.GetAll();
            if (model.Schools != null && model.Schools.Count > 0)
            {
                foreach (var item in model.Schools)
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

        // GET: Admin/School/Create
        public ActionResult Create()
        {
            ViewData["CurrentMenu"] = "education";
            School school = new School();
            school.SchoolTypes = schoolTypeService.GetAll();
            school.LevelEducations = levelEducationService.GetAll();
            return View(school);
        }
        [HttpPost]
        public ActionResult Create(School school)
        {
            ViewData["CurrentMenu"] = "education";
            school.SchoolTypes = schoolTypeService.GetAll();
            school.LevelEducations = levelEducationService.GetAll();
            bool errorFlag = false;
            if (school.LevelID == 0)
            {
                ModelState.AddModelError("LevelID", "Cấp học chưa được chọn");
                errorFlag = true;
            }
            if (!errorFlag)
            {
                int id = schoolService.Insert(school);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(school);
        }

        // GET: Admin/School/Edit/1
        public ActionResult Edit(int id)
        {
            ViewData["CurrentMenu"] = "education";
            School school = schoolService.GetByPrimaryKey(id);
            school.SchoolTypes = schoolTypeService.GetAll();
            school.LevelEducations = levelEducationService.GetAll();
            if (school != null)
            {
                return View(school);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(School school)
        {
            ViewData["CurrentMenu"] = "education";
            school.SchoolTypes = schoolTypeService.GetAll();
            school.LevelEducations = levelEducationService.GetAll();
            schoolService.Update(school);
            return RedirectToAction("Index");
        }

        public void UpdateModel(School school)
        {
            if (school.SchoolTypeID.HasValue)
            {
                school.SchoolType = schoolTypeService.GetByPrimaryKey(school.SchoolTypeID.Value);
            }
            school.LevelEducation = levelEducationService.GetByPrimaryKey(school.LevelID);
        }
    }
}