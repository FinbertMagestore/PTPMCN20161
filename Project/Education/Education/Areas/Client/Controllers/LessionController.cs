using Education.Areas.Admin.Controllers;
using Education.Areas.Admin.Model;
using Education.Areas.Admin.ModelsView;
using Education.Areas.Admin.Services;
using Education.Areas.Admin.Utilz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    //User: Huỳnh
    //TODO: CRUD Bài giảng, Xem phiên bản của file

    public class LessionController : BaseController
    {
        private LessionnService lessionService = new LessionnService();
        private SubjectService subjectService = new SubjectService();
        private ClassInfoService classInfoService = new ClassInfoService();
        private SubjectClassService subjectClassService = new SubjectClassService();
        private TeacherService teacherService = new TeacherService();
        private AccountService accountService = new AccountService();
        // GET: Client/Lession
        public ActionResult Index(int subjectID = 0, int classInfoID = 0, int page = 1)
        {
            CSS = "lession";
            LessionModel model = new LessionModel();
            model.Subjects = subjectService.GetAll();
            model.ClassInfos = classInfoService.GetAll();
            model.SubjectID = subjectID;
            model.ClassInfoID = classInfoID;
            //Page
            int pageSize = 6;
            if (page <= 0)
            {
                model.Page = 1;
            }
            else
            {
                model.Page = page;
            }

            if (subjectID > 0)
            {
                model.SubjectID = subjectID;
                model.Subject = subjectService.GetByPrimaryKey(subjectID);
            }
            if (classInfoID > 0)
            {
                model.ClassInfoID = classInfoID;
                model.ClassInfo = classInfoService.GetByPrimaryKey(classInfoID);
            }
            if (model.Subject != null && model.ClassInfo != null)
            {
                model.SubjectClass = subjectClassService.GetBySubjectAndClass(subjectID, classInfoID);
                if (model.SubjectClass != null)
                {
                    model.SubjectClassID = model.SubjectClass.ID;
                }
            }

            string where = "";
            if (subjectID > 0)
            {
                where += " and SubjectID = " + subjectID;
            }
            if (classInfoID > 0)
            {
                where += " and ClassInfoID = " + classInfoID;
            }
            where += string.Format(" and Status = {0}", (int)Config.Status.Active);
            where = where.Substring(4);
            model.Lessions = lessionService.GetByWhere(where);

            if (model.Lessions != null && model.Lessions.Count > 0)
            {
                int totalRecord = model.Lessions.Count;
                var totalPage = (totalRecord - 1) / pageSize + 1;
                model.PagerModel = new PaginationModels
                {
                    PageNumber = model.Page,
                    PageSize = pageSize,
                    TotalRecords = totalRecord,
                    TotalPages = totalPage
                };
                if (totalRecord > 0) ViewData["PagerModels"] = model.PagerModel;
                model.Lessions = model.Lessions.Skip(pageSize * (page - 1)).Take(pageSize).ToList();

                foreach (var item in model.Lessions)
                {
                    UpdateModel(item);
                }
            }
            return View(model);
        }

        // GET: Client/Lession/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo bài giảng";
            CSS = "create_lession";
            return View();
        }

        // GET: Client/Lession/Detail/1
        public ActionResult Detail(int id)
        {
            CSS = "detail_lession";
            return View();
        }

        // GET: Client/Lession/Edit/1
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            CSS = "create_lession";
            return View();
        }

        // GET: Client/Lession/Delete/1
        [Authorize(Roles = "Teacher")]
        public ActionResult Delete(int id)
        {
            CSS = "default";
            return RedirectToAction("Index");
        }

        private void UpdateModel(Lession lession)
        {
            lession.Teacher = teacherService.GetByPrimaryKey(lession.TeacherID);
            lession.Description = Util.Substring(lession.Description, 20);
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