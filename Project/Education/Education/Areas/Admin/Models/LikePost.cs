namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LikePost")]
    public partial class LikePost
    {
        public int ID { get; set; }

        public int? PostID { get; set; }

        public int? UserID { get; set; }

        public DateTime? Created { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Post Post { get; set; }
    }
}
