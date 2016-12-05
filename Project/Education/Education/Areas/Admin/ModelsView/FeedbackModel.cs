using Education.Areas.Admin.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Education.Areas.Admin.ModelsView
{
    public class FeedbackModel
    {
        public string Keyword { get; set; }
        public SelectList ListStatus { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public string Status { get; set; }
    }
}