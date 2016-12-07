namespace Education.Areas.Admin.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SubjectClass")]
    public partial class SubjectClass
    {
        public int ID { get; set; }

        public int SubjectID { get; set; }

        public int ClassInfoID { get; set; }

        public string Description { get; set; }

        public virtual ClassInfo ClassInfo { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
