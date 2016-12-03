namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClassInfo")]
    public partial class ClassInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassInfo()
        {
            SubjectClasses = new HashSet<SubjectClass>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }

        public int? LevelID { get; set; }

        public bool? Status { get; set; }

        public virtual LevelEducation LevelEducation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectClass> SubjectClasses { get; set; }
    }
}
