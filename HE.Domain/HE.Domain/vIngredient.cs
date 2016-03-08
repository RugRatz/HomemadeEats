namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("vIngredient")]
    public partial class vIngredient
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientID { get; set; }
        
        [Column(Order = 1)]
        [StringLength(30)]
        public string Ingredient_Name { get; set; }

        public DateTime? Ingredient_DateCreated { get; set; }

        public DateTime? Ingredient_LastUpdated { get; set; }
        
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientCategoryID { get; set; }
        
        [Column(Order = 3)]
        [StringLength(50)]
        public string IngredientCategory_Name { get; set; }
        
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HomemadeItemID { get; set; }
        
        [Column(Order = 5)]
        [StringLength(100)]
        public string HomemadeItem_Name { get; set; }
    }
}
