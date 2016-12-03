namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileUpload")]
    public partial class FileUpload
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileUpload()
        {
            FileUpload1 = new HashSet<FileUpload>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(10)]
        public string FileExtension { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool? Status { get; set; }

        [StringLength(200)]
        public string FileUrl { get; set; }

        public int? FileSize { get; set; }

        public int? DownloadCount { get; set; }

        public bool? IsDownload { get; set; }

        public int? OldVersion { get; set; }

        public int? LessionID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileUpload> FileUpload1 { get; set; }

        public virtual FileUpload FileUpload2 { get; set; }

        public virtual Lession Lession { get; set; }
    }
}
