namespace HE.DataAccess
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Role")]
    public partial class Role
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Role()
        //{
        //    CustomerProfiles = new HashSet<CustomerProfile>();
        //}

        public string RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CustomerProfile> CustomerProfiles { get; set; }
    }
}
