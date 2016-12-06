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
        public ActionResult Detail(int id)
        {
            CSS = "post";
            CategoryModel model = new CategoryModel();
            model.Category = categoryService.GetByPrimaryKey(id);
            model.Posts = postService.GetByCategoryID(id);

            if (model.Posts != null && model.Posts.Count > 0)
            {
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