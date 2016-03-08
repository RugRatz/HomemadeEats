namespace HE.DataAccess
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CustomerLogin")]
    public partial class CustomerLogin_NO_IDENTITY
    {
        [Key]
        [Column(Order = 0)]
        public string LoginProvider { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ProviderKey { get; set; }

        [Key]
        [Column(Order = 2)]
        public string CustomerProfileID { get; set; }

        public virtual CustomerProfile CustomerProfile { get; set; }
    }
}
