namespace HE.DataAccess
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNet.Identity.EntityFramework;

    [Table("UserClaim")]
    public class UserClaim : IdentityUserClaim
    {
        //public int UserClaimID { get; set; }

        //[Required]
        //[StringLength(128)]
        //public string CustomerProfileID { get; set; }

        //public string ClaimType { get; set; }

        //public string ClaimValue { get; set; }

        //public virtual CustomerProfile CustomerProfile { get; set; }
    }
}
