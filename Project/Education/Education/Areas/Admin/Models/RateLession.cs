namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RateLession")]
    public partial class RateLession
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? LessionID { get; set; }

        public int? Point { get; set; }

        public DateTime? Created { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Lession Lession { get; set; }
    }
}
