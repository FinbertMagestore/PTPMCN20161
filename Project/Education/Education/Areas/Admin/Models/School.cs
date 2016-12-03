namespace Education.Areas.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("School")]
    public partial class School
    {
        public int ID { get; set; }

        public int? TownID { get; set; }

        public int? SchoolTypeID { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public int? LevelID { get; set; }

        public virtual LevelEducation LevelEducation { get; set; }

        public virtual SchoolType SchoolType { get; set; }

        public virtual Town Town { get; set; }
    }
}
