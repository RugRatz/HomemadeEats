namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ingredient")]
    public partial class Ingredient
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Ingredient()
        //{
        //    GroceryGroupIngredients = new HashSet<GroceryGroupIngredient>();
        //    IngredientNotes = new HashSet<IngredientNote>();
        //    Instructions = new HashSet<Instruction>();
        //}

        [Key]
        public int IngredientID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Maximum of 30 characters.")]
        public string Name { get; set; }

        public int IngredientCategoryID { get; set; }

        public int HomemadeItemID { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GroceryGroupIngredient> GroceryGroupIngredients { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<IngredientNote> IngredientNotes { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Instruction> Instructions { get; set; }
    }
}
