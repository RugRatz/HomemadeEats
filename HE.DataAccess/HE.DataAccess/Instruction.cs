namespace HE.DataAccess
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Instruction")]
    public partial class Instruction
    {
        //this should be a primary key with identity seeding turned on but for some reason this wasn't set in SSMS 
        //I fixed it in SSMS already
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int InstructionID { get; set; }

        [Required]
        [Display(Name = "Instruction Steps", Prompt = "Add an Instruction")]
        public string Notes { get; set; }

        public int HomemadeItemID { get; set; }

        public int IngredientID { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }

        public virtual HomemadeItem HomemadeItem { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
