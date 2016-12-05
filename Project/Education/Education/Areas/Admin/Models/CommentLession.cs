namespace Education.Areas.Admin.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CommentLession")]
    public partial class CommentLession
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int LessionID { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Lession Lession { get; set; }
    }
}
