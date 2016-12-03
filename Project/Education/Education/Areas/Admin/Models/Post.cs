namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            CommentPosts = new HashSet<CommentPost>();
            LikePosts = new HashSet<LikePost>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        public int? CategoryID { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool? Status { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(100)]
        public string ImageUrl { get; set; }

        public int? UserID { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentPost> CommentPosts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LikePost> LikePosts { get; set; }
    }
}
