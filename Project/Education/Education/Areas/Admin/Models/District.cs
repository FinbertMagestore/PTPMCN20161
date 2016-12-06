namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("District")]
    public partial class District
    {
        public District()
        {
            Towns = new List<Town>();
        }

        public int ID { get; set; }

        public int ProvinceID { get; set; }

        public string Name { get; set; }

        public virtual Province Province { get; set; }

        public virtual List<Town> Towns { get; set; }
    }
}
