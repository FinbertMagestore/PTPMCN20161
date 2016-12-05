namespace Education.Areas.Admin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Lession")]
    public partial class Lession
    {
        public Lession()
        {
            CommentLessions = new List<CommentLession>();
            FileUploads = new List<FileUpload>();
            RateLessions = new List<RateLession>();
            DownloadCount = 0;
        }

        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }

        [Display(Name = "Ngày thay đổi")]
        public DateTime Modified { get; set; }

        [Display(Name = "Đường dẫn")]
        [Required(ErrorMessage = "Alias không được để trống")]
        public string Alias { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string ImageUrl { get; set; }

        [Display(Name = "Giáo viên đăng")]
        public int TeacherID { get; set; }

        [Display(Name = "Điểm đánh giá trung bình")]
        public double RateAverage { get; set; }

        [Display(Name = "Môn học")]
        public int SubjectClassID { get; set; }

        [Display(Name = "Số lượng download")]
        public int DownloadCount { get; set; }

        public virtual List<CommentLession> CommentLessions { get; set; }

        public virtual List<FileUpload> FileUploads { get; set; }

        public virtual SubjectClass SubjectClass { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual ClassInfo ClassInfo { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual List<RateLession> RateLessions { get; set; }
    }
}
