namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Subject")]
    public partial class Subject
    {
        public Subject()
        {
            Lessions = new List<Lession>();
            SubjectClasses = new List<SubjectClass>();
            Teachers = new List<Teacher>();
        }

        public int ID { get; set; }

        [Display(Name = "Tên môn học")]
        public string SubjectName { get; set; }

        public virtual List<Lession> Lessions { get; set; }

        public virtual List<SubjectClass> SubjectClasses { get; set; }

        public virtual List<Teacher> Teachers { get; set; }
    }
}
