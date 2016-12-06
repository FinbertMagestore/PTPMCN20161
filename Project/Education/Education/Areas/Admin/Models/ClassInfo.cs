namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ClassInfo")]
    public partial class ClassInfo
    {
        public ClassInfo()
        {
            SubjectClasses = new List<SubjectClass>();
        }

        public int ID { get; set; }

        [Display(Name = "Tên lớp")]
        public string ClassName { get; set; }

        [Display(Name = "Cấp học")]
        public int LevelID { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        public virtual LevelEducation LevelEducation { get; set; }

        public virtual List<SubjectClass> SubjectClasses { get; set; }
    }
}
