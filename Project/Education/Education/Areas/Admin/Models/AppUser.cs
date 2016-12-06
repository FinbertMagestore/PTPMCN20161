namespace Education.Areas.Admin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

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

        [Required(ErrorMessage = "Username không được để trống")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        //[Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Địa chỉ Email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng")]
        public string Email { get; set; }

        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? Birthday { get; set; }
        [Display(Name = "Giới tính")]
        public bool? Sex { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string ImageUrl { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        [Display(Name = "Trạng thái")]
        public bool IsActive { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastActivityDate { get; set; }

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

        [Display(Name = "Vai trò")]
        [Required(ErrorMessage = "Vai trò chưa được chọn")]
        public int RoleID { get; set; }
        public string Role { get; set; }
        public List<AspNetRole> Roles { get; set; }

        //Add
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không trùng khớp.")]
        public string ValidatePassword { get; set; }

        public bool CanDelete { get; set; }
    }
}
