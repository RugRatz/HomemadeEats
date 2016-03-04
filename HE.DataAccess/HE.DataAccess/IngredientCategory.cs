namespace HE.DataAccess
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IngredientCategory")]
    public partial class IngredientCategory
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public IngredientCategory()
        //{
        //    GroceryGroups = new HashSet<GroceryGroup>();
        //}
        [Key]
        public int IngredientCategoryID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters.")]
        [Display(Name = "Ingredient Category")]
        public string Name { get; set; }

        [Display(Description = "Is a built-in Ingredient Category?")]
        public bool? IsSystemDefault { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GroceryGroup> GroceryGroups { get; set; }
    }
}
