using Education.Areas.Admin.Controllers;
using Education.Areas.Admin.Model;
using Education.Areas.Admin.ModelsView;
using Education.Areas.Admin.Services;
using Education.Areas.Admin.Utilz;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Client.Controllers
{
    //User: Huy
    //TODO: CRUD bài viết ở phía client
    [AllowAnonymous]
    public class PostController : BaseController
    {
        private AccountService accountService = new AccountService();
        private CategoryService categoryService = new CategoryService();
        private PostService postService = new PostService();
        private const string _rootDir = "~/Assets/Admin/Upload/Posts/";

        // GET: Client/Post
        public ActionResult Index(string Keyword, int page = 1)
        {
            CSS = "post";
            PostModel model = new PostModel();
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

            model.Keyword = Keyword;
            string where = "IsHighLight = 1";
            model.Categories = categoryService.GetByWhere(where);
            if (!string.IsNullOrEmpty(Keyword))
            {
                where = string.Format("Name like N'%{0}%' or Description like N'%{1}%' or Alias like N'%{2}%' ",
                    Keyword, Keyword, Keyword);
                model.Posts = postService.GetByWhere(where);
            }
            else
            {
                model.Posts = postService.GetAllActive();
            }

            if (model.Posts != null && model.Posts.Count > 0)
            {
                int totalRecord = model.Posts.Count;
                var totalPage = (totalRecord - 1) / pageSize + 1;
                model.PagerModel = new PaginationModels
                {
                    PageNumber = model.Page,
                    PageSize = pageSize,
                    TotalRecords = totalRecord,
                    TotalPages = totalPage
                };
                if (totalRecord > 0) ViewData["PagerModels"] = model.PagerModel;
                model.Posts = model.Posts.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            }

            return View(model);
        }

        // Note: không được tạo bài viết chỉ dành cho admin: trường ForAdminPost 
        // GET: Client/Post/1
        public ActionResult Create()
        {
            CSS = "post";
            Post post = new Post();
            post.Categories = categoryService.GetAllActive(true);
            return View(post);
        }

        [HttpPost]
        public ActionResult Create(Post post, HttpPostedFileBase datafile)
        {
            CSS = "post";
            post.Categories = categoryService.GetAllActive(true);
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
            if (!errorFlag)
            {
                post.Alias = alias;
                post.Created = DateTime.Now;
                post.Modified = DateTime.Now;
                post.UserID = accountService.GetUserByUsername(User.Identity.GetUserName()).Id;
                post.Status = true;
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
                    return RedirectToAction("Detail", new { id = id });
                }
            }
            return View(post);
        }

        // GET: Client/Post/Detail/1
        public ActionResult Detail(int id)
        {
            CSS = "post";
            Post post = postService.GetByPrimaryKey(id);
            if (post != null)
            {
                post.Category = categoryService.GetByPrimaryKey(post.CategoryID);
                post.PostsSameCategory = postService.GetPostsInSameCategory(id, 4);
                foreach (var item in post.PostsSameCategory)
                {
                    item.Category = categoryService.GetByPrimaryKey(item.CategoryID);
                }
            }
            return View(post);
        }

        // GET: Client/Post/Edit/1
        public ActionResult Edit(int id)
        {
            CSS = "post";
            Post post = postService.GetByPrimaryKey(id);
            post.Categories = categoryService.GetAllActive();
            if (post == null || accountService.GetUserByUsername(User.Identity.GetUserName()).Id != post.UserID)
            {
                return RedirectToAction("Detail", new { id = id});
            }
            else
            {
                return View(post);
            }
        }
        [HttpPost]
        public ActionResult Edit(Post post, HttpPostedFileBase datafile)
        {
            ViewData["CurrentMenu"] = "category";
            post.Categories = categoryService.GetAllActive();
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
                post.Alias = alias;
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
                return RedirectToAction("Detail", new { id = post.ID });
            }
            return View(post);
        }
        // GET: Client/Post/Delete/1
        public ActionResult Delete(int id)
        {
            CSS = "default";
            return RedirectToAction("Index");
        }
    }
}