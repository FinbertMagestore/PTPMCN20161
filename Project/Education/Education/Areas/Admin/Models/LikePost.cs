namespace Education.Areas.Admin.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LikePost")]
    public partial class LikePost
    {
        public int ID { get; set; }

        public int PostID { get; set; }

        public int UserID { get; set; }

        public DateTime Created { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Post Post { get; set; }
    }
}
