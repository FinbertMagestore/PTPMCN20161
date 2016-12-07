namespace Education.Areas.Admin.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FileUpload")]
    public partial class FileUpload
    {
        public FileUpload()
        {
            FileUploads = new List<FileUpload>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "Tên file")]
        public string FileName { get; set; }

        [Display(Name = "Đuôi file")]
        public string FileExtension { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }

        [Display(Name = "Ngày thay đổi")]
        public DateTime Modified { get; set; }

        [Display(Name = "")]
        public bool Status { get; set; }

        [Display(Name = "Trạng thái")]
        public string FileUrl { get; set; }

        [Display(Name = "Kích thước")]
        public int FileSize { get; set; }

        [Display(Name = "Số lượng download")]
        public int DownloadCount { get; set; }

        [Display(Name = "Được download")]
        public bool IsDownload { get; set; }

        [Display(Name = "Phiên bản cũ")]
        public int OldVersionID { get; set; }

        [Display(Name = "Bài giảng")]
        public int LessionID { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public virtual List<FileUpload> FileUploads { get; set; }

        public virtual FileUpload OldVersion { get; set; }

        public virtual Lession Lession { get; set; }
    }
}
