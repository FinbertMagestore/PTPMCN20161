using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.ModelsView
{
    public class CategoryModel
    {
        public string Keyword { get; set; }
        public SelectList ListStatus { get; set; }
        public List<Category> Categories { get; set; }
        public string Status { get; set; }
    }
}