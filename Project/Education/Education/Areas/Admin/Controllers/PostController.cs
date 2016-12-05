using Education.Areas.Admin.Model;
using Education.Areas.Admin.ModelsView;
using Education.Areas.Admin.Services;
using Education.Areas.Admin.Utilz;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Areas.Admin.Utilz;

namespace Education.Areas.Admin.Controllers
{
    //User: Huy
    // TODO: CRUD Post

    [Authorize(Roles = "Admin")]
    public class PostController : AdminBaseController
    {
        private PostService postService = new PostService();
        private CategoryService categoryService = new CategoryService();
        private AccountService accountService = new AccountService();
        private const string _rootDir = "~/Assets/Admin/Upload/Posts/";

        // GET: Admin/Post
        public ActionResult Index()
        {
            ViewData["CurrentMenu"] = "category";
            PostModel model = new PostModel();
            model.Posts = postService.GetAll();
            if (model.Posts != null && model.Posts.Count > 0)
            {
                foreach (var item in model.Posts)
                {
                    item.Category = categoryService.GetByPrimaryKey(item.CategoryID);
                }
            }
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Hiển thị", Value = "1" },
                new SelectListItem{ Text = "Ẩn", Value = "0" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PostModel model)
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
            model.Posts = postService.GetByWhere(where);
            if (model.Posts != null && model.Posts.Count > 0)
            {
                foreach (var item in model.Posts)
                {
                    item.Category = categoryService.GetByPrimaryKey(item.CategoryID);
                }
            }
            model.ListStatus = new SelectList(new[]
            {
                new SelectListItem{ Text = "Hiển thị", Value = "1" },
                new SelectListItem{ Text = "Ẩn", Value = "0" }
            }, "Value", "Text", model.Status);
            return View(model);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            ViewData["CurrentMenu"] = "category";
            Post post = new Post();
            post.Categories = categoryService.GetAll();
            return View(post);
        }
        [HttpPost]
        public ActionResult Create(Post post, HttpPostedFileBase datafile)
        {
            ViewData["CurrentMenu"] = "category";
            post.Categories = categoryService.GetAll();
            ViewData["CurrentMenu"] = "category";
            var alias = Util.GetSEOAlias(post.Alias);
            Post postByAlias = postService.GetByAlias(post.Alias, post.CategoryID);
            bool errorFlag = false;
            if (post.CategoryID == 0)
            {
                ModelState.AddModelError("CategoryID", "Chuyên mục chưa được chọn");
                errorFlag = true;
            }
            if (postByAlias != null)
            {
                ModelState.AddModelError("Alias", "Alias đã được sử dụng");
                errorFlag = true;
            }
            else
            {
                post.Alias = alias;
            }
            if (!errorFlag)
            {
                post.Created = DateTime.Now;
                post.Modified = DateTime.Now;
                post.UserID = accountService.GetUserId(User.Identity.GetUserName());
                int id = postService.Insert(post);
                if (id > 0)
                {
                    post.ID = id;
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
                            post.ImageUrl = filePath;
                            postService.Update(post);
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(post);
        }

        // GET: Admin/Post/Edit/1
        public ActionResult Edit(int id)
        {
            ViewData["CurrentMenu"] = "category";
            Post post = postService.GetByPrimaryKey(id);
            post.Categories = categoryService.GetAll();
            if (post != null)
            {
                return View(post);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(Post post, HttpPostedFileBase datafile)
        {
            ViewData["CurrentMenu"] = "category";
            post.Categories = categoryService.GetAll();
            string alias = Util.GetSEOAlias(post.Alias);
            Post postByAlias = postService.GetByAlias(alias, post.CategoryID);
            bool errorFlag = false;
            if (post.CategoryID == 0)
            {
                ModelState.AddModelError("CategoryID", "Chuyên mục chưa được chọn");
                errorFlag = true;
            }
            if (postByAlias != null && postByAlias.ID != post.ID)
            {
                ModelState.AddModelError("Alias", "Alias đã được sử dụng");
                errorFlag = true;
            }
            if (!errorFlag)
            {
                post.Modified = DateTime.Now;
                if (datafile != null)
                {
                    string[] fileExtensions = { ".jpg", ".jpeg", ".gif", ".png" };
                    string extension = Path.GetExtension(datafile.FileName).ToLower();
                    if (fileExtensions.Contains(extension))
                    {
                        if (!String.IsNullOrEmpty(post.ImageUrl))
                        {
                            string fileName = Server.MapPath(post.ImageUrl);
                            if (System.IO.File.Exists(fileName))
                            {
                                System.IO.File.Delete(fileName);
                            }
                        }
                        string currentDir = _rootDir + post.ID + "/";
                        var filePath = currentDir + datafile.FileName;
                        if (!Directory.Exists(Server.MapPath(currentDir)))
                        {
                            Directory.CreateDirectory(Server.MapPath(currentDir));
                        }
                        var path = Path.Combine(Server.MapPath(currentDir), Path.GetFileName(datafile.FileName));
                        datafile.SaveAs(path);
                        post.ImageUrl = filePath;
                    }
                }
                postService.Update(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Admin/Post/Delete/1
        public ActionResult Delete(int id)
        {
            ViewData["CurrentMenu"] = "category";
            Post post = postService.GetByPrimaryKey(id);
            post.Category = categoryService.GetByPrimaryKey(post.CategoryID);
            if (post != null)
            {
                return View(post);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Delete(Post post)
        {
            postService.DeleteByPrimaryKey(post.ID);
            if (!String.IsNullOrEmpty(post.ImageUrl))
            {
                string fileName = Server.MapPath(post.ImageUrl);
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