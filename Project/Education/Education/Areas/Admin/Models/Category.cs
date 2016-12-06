namespace Education.Areas.Admin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Posts = new List<Post>();
        }

        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Loại danh mục")]
        public int CategoryTypeID { get; set; }

        [Display(Name = "Đường dẫn")]
        [Required(ErrorMessage = "Alias không được để trống")]
        public string Alias { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }

        [Display(Name = "Ngày thay đổi")]
        public DateTime Modified { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string ImageUrl { get; set; }

        [Display(Name = "Chỉ admin được đăng")]
        public bool ForAdminPost { get; set; }

        [Display(Name = "Chuyên mục nổi bật")]
        public bool IsHighLight { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
