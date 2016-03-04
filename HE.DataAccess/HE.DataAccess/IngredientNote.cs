namespace HE.DataAccess
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IngredientNote")]
    public partial class IngredientNote
    {
        [Key]
        public int IngredientNoteID { get; set; }

        public int IngredientID { get; set; }

        [StringLength(250, ErrorMessage = "Maximum of 250 characters.")]
        [Display(Prompt = "Add notes")]
        public string Note { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
