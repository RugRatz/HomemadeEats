namespace HE.DataAccess
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserClaim")]
    public partial class UserClaim_NO_IDENTITY
    {
        public int UserClaimID { get; set; }

        [Required]
        [StringLength(128)]
        public string CustomerProfileID { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public virtual CustomerProfile CustomerProfile { get; set; }
    }
}
