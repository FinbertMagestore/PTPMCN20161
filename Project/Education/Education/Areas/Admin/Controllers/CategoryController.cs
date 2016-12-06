using Education.Areas.Admin.Model;
using Education.Areas.Admin.ModelsView;
using Education.Areas.Admin.Services;
using Education.Areas.Admin.Utilz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.Controllers
{
    //User: Huy
    // TODO CRUD Chuyên mục

    [Authorize(Roles = "Admin")]
    public class CategoryController : AdminBaseController
    {
        private CategoryService categoryService = new CategoryService();
        private const string _rootDir = "~/Assets/Admin/Upload/Categories/";

        // GET: Admin/Category
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "category";
            CategoryModel model = new CategoryModel();
            model.Categories = categoryService.GetAll();
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Hiển thị", Value = "1" },
                new SelectListItem{ Text = "Ẩn", Value = "0" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CategoryModel model)
        {
            ViewData["CurrentMenu"] = "category";
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
            model.Categories = categoryService.GetByWhere(where);
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Hiển thị", Value = "1" },
                new SelectListItem{ Text = "Ẩn", Value = "0" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewData["CurrentMenu"] = "category";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category, HttpPostedFileBase datafile)
        {
            ViewData["CurrentMenu"] = "category";
            var alias = Util.GetSEOAlias(category.Alias);
            Category categoryByAlias = categoryService.GetByAlias(category.Alias);
            bool errorFlag = false;
            if (categoryByAlias != null)
            {
                ModelState.AddModelError("Alias", "Alias đã được sử dụng");
                errorFlag = true;
            }
            else
            {
                category.Alias = alias;
            }
            if (!errorFlag)
            {
                category.Created = DateTime.Now;
                category.Modified = DateTime.Now;
                int id = categoryService.Insert(category);
                if (id > 0)
                {
                    category.ID = id;
                    if (datafile != null)
                    {
                        string[] fileExtensions = { ".jpg", ".jpeg", ".gif", ".png" };
                        string extension = Path.GetExtension(datafile.FileName).ToLower();
                        if (fileExtensions.Contains(extension))
                        {
                            string currentDir = _rootDir + id + "/";
                            var filePath = currentDir + datafile.FileName;
                            if (!Directory.Exists(Server.MapPath(currentDir)))
                            {
                                Directory.CreateDirectory(Server.MapPath(currentDir));
                            }
                            var path = Path.Combine(Server.MapPath(currentDir), Path.GetFileName(datafile.FileName));
                            datafile.SaveAs(path);
                            category.ImageUrl = filePath;
                            categoryService.Update(category);
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }

        // GET: Admin/Category/Edit/1
        public ActionResult Edit(int id)
        {
            ViewData["CurrentMenu"] = "category";
            Category category = categoryService.GetByPrimaryKey(id);
            if (category != null)
            {
                return View(category);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Category category, HttpPostedFileBase datafile)
        {
            string alias = Util.GetSEOAlias(category.Alias);
            Category categoryByAlias = categoryService.GetByAlias(alias);
            bool errorFlag = false;
            if (categoryByAlias != null && categoryByAlias.ID != category.ID)
            {
                ModelState.AddModelError("Alias", "Alias đã được sử dụng");
                errorFlag = true;
            }
            if (!errorFlag)
            {
                category.Modified = DateTime.Now;
                if (datafile != null)
                {
                    string[] fileExtensions = { ".jpg", ".jpeg", ".gif", ".png" };
                    string extension = Path.GetExtension(datafile.FileName).ToLower();
                    if (fileExtensions.Contains(extension))
                    {
                        if (!String.IsNullOrEmpty(category.ImageUrl))
                        {
                            string fileName = Server.MapPath(category.ImageUrl);
                            if (System.IO.File.Exists(fileName))
                            {
                                System.IO.File.Delete(fileName);
                            }
                        }
                        string currentDir = _rootDir + category.ID + "/";
                        var filePath = currentDir + datafile.FileName;
                        if (!Directory.Exists(Server.MapPath(currentDir)))
                        {
                            Directory.CreateDirectory(Server.MapPath(currentDir));
                        }
                        var path = Path.Combine(Server.MapPath(currentDir), Path.GetFileName(datafile.FileName));
                        datafile.SaveAs(path);
                        category.ImageUrl = filePath;
                    }
                }
                categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/1
        public ActionResult Delete(int id)
        {
            ViewData["CurrentMenu"] = "category";
            Category category = categoryService.GetByPrimaryKey(id);
            category.Posts = categoryService.GetAllPostInCategory(id);
            if (category != null)
            {
                return View(category);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            List<Post> posts = categoryService.GetAllPostInCategory(category.ID);
            if (!String.IsNullOrEmpty(category.ImageUrl))
            {
                string fileName = Server.MapPath(category.ImageUrl);
                if (System.IO.File.Exists(fileName))
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    Directory.Delete(fileInfo.Directory.FullName, true);
                }
            }
            if (posts == null || posts.Count == 0)
            {
                categoryService.DeleteByPrimaryKey(category.ID);
            }
            return RedirectToAction("Index");
        }
    }
}