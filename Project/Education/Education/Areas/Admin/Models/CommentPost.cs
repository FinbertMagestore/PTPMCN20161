namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommentPost")]
    public partial class CommentPost
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? PostID { get; set; }

        [StringLength(200)]
        public string Content { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Post Post { get; set; }
    }
}
