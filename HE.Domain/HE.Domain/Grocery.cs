namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Grocery")]
    public partial class Grocery
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Grocery()
        //{
        //    GroceryGroups = new HashSet<GroceryGroup>();
        //}

        [Key]
        public int GroceryID { get; set; }

        public int HomemadeItemID { get; set; }

        [Display(Name = "Completed?")]
        public bool? IsCompleted { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }

        public virtual HomemadeItem HomemadeItem { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GroceryGroup> GroceryGroups { get; set; }
    }
}
