namespace Education.Areas.Admin.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CommentPost")]
    public partial class CommentPost
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int PostID { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Post Post { get; set; }
    }
}
