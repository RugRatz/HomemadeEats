namespace HE.DataAccess
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNet.Identity.EntityFramework;

    [Table("CustomerLogin")]
    public class CustomerLogin : IdentityUserLogin
    {
        //[Key]
        //[Column(Order = 0)]
        //public string LoginProvider { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //public string ProviderKey { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //public string CustomerProfileID { get; set; }

        //public virtual CustomerProfile CustomerProfile { get; set; }
    }
}
