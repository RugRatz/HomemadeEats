namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("vCustomer")]
    public partial class vCustomer
    {
        [Key]
        [Column(Order = 0)]
        public string CustomerProfileID { get; set; }
        
        [Column(Order = 1)]
        public bool CustomerProfile_IsActive { get; set; }
        
        [Column(Order = 2)]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Column(Order = 3)]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [Column(Order = 4)]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string EmailAddress { get; set; }
        
        [Column(Order = 5)]
        public bool EmailAddressConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public DateTime? LockoutEndDateUTC { get; set; }
        
        [Column(Order = 6)]
        public bool LockoutEnabled { get; set; }
        
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccessFailedCount { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }
        
        [Column(Order = 8)]
        public bool PhoneNumberConfirmed { get; set; }
        
        [Column(Order = 9)]
        public bool TwoFactorAuthEnabled { get; set; }

        public string SecurityStamp { get; set; }

        [StringLength(150)]
        public string AvatarTitle { get; set; }

        [StringLength(256)]
        public string AvatarFilePath { get; set; }

        public DateTime? CustomerProfile_DateCreated { get; set; }

        public DateTime? CustomerProfile_LastUpdated { get; set; }
        
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerContactInfoID { get; set; }

        public bool? CustomerContactInfo_IsActive { get; set; }

        [StringLength(40)]
        public string Street { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(15)]
        public string StateOrProvince { get; set; }

        [StringLength(12)]
        public string ZipOrPostalCode { get; set; }

        [StringLength(48)]
        public string Country { get; set; }

        public DateTime? CustomerContactInfo_DateCreated { get; set; }

        public DateTime? CustomerContactInfo_LastUpdated { get; set; }
    }
}
