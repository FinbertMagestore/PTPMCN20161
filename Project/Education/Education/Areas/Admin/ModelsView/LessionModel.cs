using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Areas.Admin.ModelsView
{
    public class LessionModel
    {
        public string Keyword { get; set; }
        public SelectList ListStatus { get; set; }
        public List<Lession> Lessions { get; set; }
        public string Status { get; set; }
        public List<ClassInfo> ClassInfos { get; set; }
        public int ClassInfoID { get; set; }
        public ClassInfo ClassInfo { get; set; }
        public List<Subject> Subjects { get; set; }
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
        public int SubjectClassID { get; set; }
        public SubjectClass SubjectClass { get; set; }
        public PaginationModels PagerModel { get; set; }
        public int Page { get; set; }
    }
}