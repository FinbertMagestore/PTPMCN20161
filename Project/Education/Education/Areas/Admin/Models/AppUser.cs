namespace Education.Areas.Admin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AppUser
    {
        public AppUser()
        {
            AspNetUserClaims = new List<AspNetUserClaim>();
            CommentLessions = new List<CommentLession>();
            CommentPosts = new List<CommentPost>();
            LikePosts = new List<LikePost>();
            Posts = new List<Post>();
            RateLessions = new List<RateLession>();
            Reports = new List<Report>();
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Roles = new List<AspNetRole>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Họ tên")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng")]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastActivityDate { get; set; }

        [Required]
        public string SecurityStamp { get; set; }

        public virtual List<AspNetUserClaim> AspNetUserClaims { get; set; }

        public virtual List<CommentLession> CommentLessions { get; set; }

        public virtual List<CommentPost> CommentPosts { get; set; }

        public virtual List<LikePost> LikePosts { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<RateLession> RateLessions { get; set; }

        public virtual List<Report> Reports { get; set; }

        public virtual List<Student> Students { get; set; }

        public virtual List<Teacher> Teachers { get; set; }

        public virtual List<AspNetRole> Roles { get; set; }

        //Add
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không trùng khớp.")]
        public string ValidatePassword { get; set; }
    }
}
