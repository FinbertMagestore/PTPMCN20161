namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Province")]
    public partial class Province
    {
        public Province()
        {
            Districts = new List<District>();
        }

        public int ID { get; set; }

        [Display(Name = "Tên tỉnh")]
        public string Name { get; set; }

        public virtual List<District> Districts { get; set; }
    }
}
