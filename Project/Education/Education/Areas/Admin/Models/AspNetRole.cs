namespace Education.Areas.Admin.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class AspNetRole
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên")]
        public string Name { get; set; }
    }
}
