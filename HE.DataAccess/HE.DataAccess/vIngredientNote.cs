namespace HE.DataAccess
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("vIngredientNote")]
    public partial class vIngredientNote
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientNoteID { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public DateTime? DateCreatedUTC { get; set; }

        public DateTime? LastUpdatedUTC { get; set; }
        
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientID { get; set; }
        
        [Column(Order = 2)]
        [StringLength(30)]
        public string Ingredient_Name { get; set; }
    }
}
