namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Teacher")]
    public partial class Teacher
    {
        public Teacher()
        {
            this.Lessions = new List<Lession>();
            this.AppUser = new AppUser();
            this.Subject = new Subject();
            this.School = new School();
        }

        public int ID { get; set; }

        public int UserID { get; set; }

        [Display(Name = "Số năm kinh nghiệm")]
        public int ExperienceYear { get; set; }

        [Display(Name = "Môn dạy chính")]
        public int MainSubjectID { get; set; }

        [Display(Name = "Tên trường học")]
        public string SchoolName { get; set; }

        [Display(Name = "Tên trường học")]
        public int? SchoolID { get; set; }
        public School School { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual List<Lession> Lessions { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
