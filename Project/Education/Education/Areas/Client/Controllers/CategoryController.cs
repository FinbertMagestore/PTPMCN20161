using Education.Areas.Admin.Controllers;
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
    public class CategoryController : BaseController
    {
        private CategoryService categoryService = new CategoryService();
        private PostService postService = new PostService();
        // GET: Client/Category
        public ActionResult Index()
        {
            CSS = "post";
            CategoryModel model = new CategoryModel();
            model.Categories = categoryService.GetAllActive();
            return View(model);
        }

        // GET: Client/Category/Detail
        public ActionResult Detail(int id, int page = 1)
        {
            CSS = "post";
            CategoryModel model = new CategoryModel();
            //Page
            int pageSize = 2;
            if (page <= 0)
            {
                model.Page = 1;
            }
            else
            {
                model.Page = page;
            }
            model.Category = categoryService.GetByPrimaryKey(id);
            model.Posts = postService.GetByCategoryID(id);

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

                foreach (var item in model.Posts)
                {
                    item.Description = Substring(item.Description, 26);

                    if (item.CategoryID > 0)
                    {
                        item.Category = categoryService.GetByPrimaryKey(item.CategoryID);
                    }
                }
            }
            return View(model);
        }


        /// <summary>
        /// Rút ngắn string xuống với số từ tối đa và gắn thêm 3 ký tự mở rộng vào cuối
        /// Ví dụ: bài giảng => bài giảng ...
        /// </summary>
        /// <param name="input"></param>
        /// <param name="maxWord"></param>
        /// <returns></returns>
        public static string Substring(string input, int maxWord)
        {
            try
            {
                var temp = StripHtmlTags(input);
                string[] wordsInString = temp.Split(' ');
                if (wordsInString != null && wordsInString.Length > 26)
                {
                    string newDescription = "";
                    for (int i = 0; i < maxWord; i++)
                    {
                        newDescription += wordsInString[i] + " ";
                    }
                    newDescription += " ... ";
                    return newDescription;
                }
                return input;
            }
            catch (System.Exception)
            {
                return "";
            }
        }

        private static string StripHtmlTags(string html)
        {
            if (string.IsNullOrEmpty(html)) return "";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return HttpUtility.HtmlDecode(doc.DocumentNode.InnerText);
        }
    }
}