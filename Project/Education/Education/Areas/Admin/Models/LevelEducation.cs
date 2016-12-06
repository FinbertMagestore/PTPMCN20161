namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LevelEducation")]
    public partial class LevelEducation
    {
        public LevelEducation()
        {
            Classes = new List<ClassInfo>();
            Schools = new List<School>();
        }

        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public virtual List<ClassInfo> Classes { get; set; }

        public virtual List<School> Schools { get; set; }
    }
}
