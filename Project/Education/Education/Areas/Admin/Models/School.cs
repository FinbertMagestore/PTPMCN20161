namespace Education.Areas.Admin.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("School")]
    public partial class School
    {
        public int ID { get; set; }

        [Display(Name = "Xã")]
        public int TownID { get; set; }

        [Display(Name = "Loại trường")]
        public int SchoolTypeID { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Cấp học")]
        public int LevelID { get; set; }

        public virtual LevelEducation LevelEducation { get; set; }

        public virtual SchoolType SchoolType { get; set; }

        public virtual Town Town { get; set; }
    }
}
