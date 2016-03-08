namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CustomerContactInfo")]
    public partial class CustomerContactInfo
    {
        [Key]
        public int CustomerContactInfoID { get; set; }

        public string CustomerProfileID { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(40, ErrorMessage = "Maximum of 40 characters.")]
        [Display(Prompt = "Enter Street")]
        public string Street { get; set; }

        [StringLength(20, ErrorMessage = "Maximum of 20 characters.")]
        [Display(Prompt = "Enter City")]
        public string City { get; set; }

        [StringLength(15, ErrorMessage = "Maximum of 15 characters.")]
        [Display(Name = "State/Province", Prompt = "Enter State or Province")]
        public string StateOrProvince { get; set; }

        [StringLength(12, ErrorMessage = "Maximum of 12 characters.")]
        [Display(Name = "Zip/Postal Code", Prompt = "Enter Zip or Postal Code")]
        public string ZipOrPostalCode { get; set; }

        [StringLength(48, ErrorMessage = "Maximum of 48 characters.")]
        [Display(Prompt = "Enter Country")]
        public string Country { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }
    }
}
