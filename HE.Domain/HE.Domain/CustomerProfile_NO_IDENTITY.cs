namespace HE.DataAccess
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CustomerProfile")]
    public partial class CustomerProfile_NO_IDENTITY
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public CustomerProfile()
        //{
        //    CustomerLogins = new HashSet<CustomerLogin>();
        //    UserClaims = new HashSet<UserClaim>();
        //    Roles = new HashSet<Role>();
        //}

        [Key]
        public string CustomerProfileID { get; set; }

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

        [StringLength(100, ErrorMessage = "Maximum of 50 characters.")]
        [Display(Name = "Email Address", Prompt = "Enter Email Address", Description = "Customer Email Address")]
        public string EmailAddress { get; set; }

        public bool EmailAddressConfirmed { get; set; }

        //this may not be required for external login
        //[Required(ErrorMessage = "Maximum of 20 characters.")]
        [Display(Prompt = "Enter Password")]
        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        [StringLength(50)]
        [Display(Name = "Phone Number",
            Prompt = "Enter Phone Number", Description = "Contact phone number")]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorAuthEnabled { get; set; }

        public DateTime? LockoutEndDateUTC { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CustomerLogin> CustomerLogins { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<UserClaim> UserClaims { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Role> Roles { get; set; }
    }
}
