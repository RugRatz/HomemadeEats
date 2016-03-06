namespace HE.DataAccess
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using System.Threading.Tasks;
    [Table("CustomerProfile")]
    public class CustomerProfile : IdentityUser
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public CustomerProfile()
        //{
        //    CustomerLogins = new HashSet<CustomerLogin>();
        //    UserClaims = new HashSet<UserClaim>();
        //    Roles = new HashSet<Role>();
        //}


        #region This was my attempt at overriding the primary key type to change it to INT but no luck
        //[Key]
        //public int CustomerProfileID { get; set; }
        //public override str Id { get; set; }
        //public override string Id
        //{
        //    get
        //    {
        //        return base.Id;
        //    }

        //    set
        //    {
        //        base.Id = value as int;
        //    }
        //}
        #endregion

        [Required]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters.")]
        [Display(Name = "First Name", Prompt = "Enter First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters.")]
        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        [StringLength(150, ErrorMessage = "Maximum of 150 characters.")]
        [Display(Name = "Avatar Title", Prompt = "Add an Avatar")]
        public string AvatarTitle { get; set; }

        [StringLength(256, ErrorMessage = "Maximum of 250 characters.")]
        [Display(Name = "Avatar File Location", Prompt = "Avatar File Location")]
        public string AvatarFilePath { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUtc { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUtc { get; set; }
        
       
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CustomerProfile> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CustomerProfile> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        
        //Attempted to implement FindAsync but not sure how to implement this yet
        //public async Task<CustomerProfile> FindAsync(string id)
        //{
        //    return CustomerProfile.
        //}
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CustomerLogin> CustomerLogins { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UserClaim> UserClaims { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Role> Roles { get; set; }
    }
}
