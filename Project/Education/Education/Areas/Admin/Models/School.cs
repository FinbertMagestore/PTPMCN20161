namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("School")]
    public partial class School
    {
        public School()
        {
            this.Town = new Town();
            this.LevelEducation = new LevelEducation();
            this.SchoolType = new SchoolType();
            this.SchoolTypes = new List<SchoolType>();
        }

        public int ID { get; set; }

        [Display(Name = "Tên trường")]
        [Required(ErrorMessage = "Tên trường không được để trống")]
        public string Name { get; set; }

        [Display(Name = "Xã")]
        public int? TownID { get; set; }

        [Display(Name = "Loại trường")]
        public int? SchoolTypeID { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ trường không được để trống")]
        public string Address { get; set; }

        [Display(Name = "Cấp học")]
        [Required(ErrorMessage = "Cấp học chưa được chọn")]
        public int LevelID { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        public virtual LevelEducation LevelEducation { get; set; }
        public List<LevelEducation> LevelEducations { get; set; }
        public virtual SchoolType SchoolType { get; set; }
        public List<SchoolType> SchoolTypes { get; set; }

        public virtual Town Town { get; set; }
    }
}
