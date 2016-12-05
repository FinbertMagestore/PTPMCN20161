namespace Education.Areas.Admin.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Report")]
    public partial class Report
    {
        public int ID { get; set; }

        [Display(Name = "Người báo cáo")]
        public int UserID { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string Content { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }

        [Display(Name = "Loại báo cáo")]
        [Required(ErrorMessage = "Loại báo cáo chưa được chọn")]
        public int ReportTypeID { get; set; }

        [Display(Name = "Ảnh mô tả")]
        public string ImageUrl { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual ReportType ReportType { get; set; }

        [Display(Name = "Trạng thái")]
        public bool State { get; set; }
    }
}
