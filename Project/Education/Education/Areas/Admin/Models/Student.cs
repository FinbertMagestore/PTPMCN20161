namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? CurrentClass { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
