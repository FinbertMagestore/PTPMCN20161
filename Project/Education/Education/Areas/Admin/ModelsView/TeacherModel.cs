using Education.Areas.Admin.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Education.Areas.Admin.ModelsView
{
    public class TeacherModel
    {
        public string Keyword { get; set; }
        public SelectList ListStatus { get; set; }
        public List<Teacher> Teachers { get; set; }
        public string Status { get; set; }
    }
}