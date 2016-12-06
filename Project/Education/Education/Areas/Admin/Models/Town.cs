namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Town")]
    public partial class Town
    {
        public Town()
        {
            Schools = new List<School>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int DistrictID { get; set; }

        public string Name { get; set; }

        public virtual District District { get; set; }

        public virtual List<School> Schools { get; set; }
    }
}
