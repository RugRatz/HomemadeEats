namespace HE.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GroceryGroupIngredient")]
    public partial class GroceryGroupIngredient
    {
        [Key]
        public int GroceryGroupIngredientID { get; set; }

        public int GroceryGroupID { get; set; }

        public int IngredientID { get; set; }

        [Display(Name = "Completed?")]
        public bool? IsDone { get; set; }

        public virtual GroceryGroup GroceryGroup { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
