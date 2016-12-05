namespace Education.Areas.Admin.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int ID { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string Content { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }

        [Display(Name = "Trạng thái")]
        public bool State { get; set; }

        [Display(Name = "Ảnh mô tả")]
        public string ImageUrl { get; set; }

    }
}
