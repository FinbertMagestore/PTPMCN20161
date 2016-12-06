namespace Education.Areas.Admin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using System.Web.Mvc;

    [Table("Post")]
    public partial class Post
    {
        public Post()
        {
            CommentPosts = new List<CommentPost>();
            LikePosts = new List<LikePost>();
        }

        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Name { get; set; }

        [Display(Name = "Đường dẫn")]
        [Required(ErrorMessage = "Alias không được để trống")]
        public string Alias { get; set; }

        [Display(Name = "Chuyên mục")]
        public int CategoryID { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }

        [Display(Name = "Ngày thay đổi")]
        public DateTime Modified { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Nội dung")]
        [AllowHtml]
        public string Content { get; set; }

        [Display(Name = "Mô tả")]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string ImageUrl { get; set; }

        [Display(Name = "Người đăng")]
        public int UserID { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<CommentPost> CommentPosts { get; set; }

        public virtual List<LikePost> LikePosts { get; set; }

        public HttpPostedFileBase datafile { get; set; }

        //Add
        public List<Category> Categories { get; set; }

        public List<Post> PostsSameCategory { get; set; }

    }
}
