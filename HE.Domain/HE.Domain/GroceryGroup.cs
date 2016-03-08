namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GroceryGroup")]
    public partial class GroceryGroup
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public GroceryGroup()
        //{
        //    GroceryGroupIngredients = new HashSet<GroceryGroupIngredient>();
        //}
        [Key]
        public int GroceryGroupID { get; set; }

        [Display(Name = "Completed?")]
        public bool? IsDone { get; set; }

        public int IngredientCategoryID { get; set; }

        public int GroceryID { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }

        public virtual Grocery Grocery { get; set; }

        public virtual IngredientCategory IngredientCategory { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GroceryGroupIngredient> GroceryGroupIngredients { get; set; }
    }
}
