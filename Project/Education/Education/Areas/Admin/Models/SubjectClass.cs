namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubjectClass")]
    public partial class SubjectClass
    {
        public int ID { get; set; }

        public int? SubjectID { get; set; }

        public int? ClassID { get; set; }

        public virtual ClassInfo ClassInfo { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
