namespace Education.Areas.Admin.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RateLession")]
    public partial class RateLession
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int LessionID { get; set; }

        public int Point { get; set; }

        public DateTime Created { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Lession Lession { get; set; }
    }
}
