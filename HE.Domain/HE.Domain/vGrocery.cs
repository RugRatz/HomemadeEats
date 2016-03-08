namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("vGrocery")]
    public partial class vGrocery
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HomemadeItemID { get; set; }
        
        [Column(Order = 1)]
        [StringLength(100)]
        public string HomemadeItem_Name { get; set; }
        
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MealTypeID { get; set; }
        
        [Column(Order = 3)]
        public string MealType_Name { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroceryID { get; set; }

        public bool? IsCompleted { get; set; }

        public DateTime? Grocery_DateCreated { get; set; }

        public DateTime? Grocery_LastUpdated { get; set; }
        
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroceryGroupID { get; set; }

        public bool? GroceryGroup_IsDone { get; set; }

        public DateTime? GroceryGroup_DateCreated { get; set; }

        public DateTime? GroceryGroup_LastUpdated { get; set; }
        
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientCategoryID { get; set; }
        
        [Column(Order = 7)]
        [StringLength(50)]
        public string IngredientCategory_Name { get; set; }
        
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroceryGroupIngredientID { get; set; }

        public bool? GroceryGroupIngredient_IsDone { get; set; }
        
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientID { get; set; }
        
        [Column(Order = 10)]
        [StringLength(30)]
        public string Ingredient_Name { get; set; }
    }
}
