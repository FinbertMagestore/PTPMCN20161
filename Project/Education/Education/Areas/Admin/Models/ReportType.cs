namespace Education.Areas.Admin.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ReportType")]
    public partial class ReportType
    {
        public ReportType()
        {
            Reports = new List<Report>();
        }

        public int ID { get; set; }

        [Display(Name = "Mã")]
        public string Code { get; set; }

        [Display(Name = "Tên loại báo cáo")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        public virtual List<Report> Reports { get; set; }
    }
}
