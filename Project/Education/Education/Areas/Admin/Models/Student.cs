namespace Education.Areas.Admin.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            this.AppUser = new AppUser();
            this.ClassInfo = new ClassInfo();
            this.School = new School();
        }

        public int ID { get; set; }

        public int UserID { get; set; }

        [Display(Name = "Lớp hiện tại")]
        public int ClassInfoID { get; set; }

        [Display(Name = "Tên lớp")]
        public string ClassName { get; set; }

        [Display(Name = "Tên trường học")]
        public string SchoolName { get; set; }

        [Display(Name = "Tên trường học")]
        public int? SchoolID { get; set; }

        public School School { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual ClassInfo ClassInfo { get; set; }
    }
}
