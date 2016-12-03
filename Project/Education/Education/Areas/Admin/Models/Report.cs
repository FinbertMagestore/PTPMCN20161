namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        [StringLength(200)]
        public string Content { get; set; }

        public DateTime? Created { get; set; }

        public int? ReportTypeID { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual ReportType ReportType { get; set; }
    }
}
