namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SchoolType")]
    public partial class SchoolType
    {
        public SchoolType()
        {
            Schools = new List<School>();
        }

        public int ID { get; set; }

        [Display(Name = "Mã")]
        public string Code { get; set; }

        [Display(Name = "Tên loại trường")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public virtual List<School> Schools { get; set; }
    }
}
