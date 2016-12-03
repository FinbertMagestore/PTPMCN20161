namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lession")]
    public partial class Lession
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lession()
        {
            CommentLessions = new HashSet<CommentLession>();
            FileUploads = new HashSet<FileUpload>();
            RateLessions = new HashSet<RateLession>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(100)]
        public string Alias { get; set; }

        public bool? Status { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }

        public int? TeacherID { get; set; }

        public double? RateAverage { get; set; }

        public int? SubjectID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentLession> CommentLessions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileUpload> FileUploads { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RateLession> RateLessions { get; set; }
    }
}
