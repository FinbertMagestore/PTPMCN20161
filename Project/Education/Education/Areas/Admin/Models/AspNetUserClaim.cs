namespace Education.Areas.Admin.Model
{
    public partial class AspNetUserClaim
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
