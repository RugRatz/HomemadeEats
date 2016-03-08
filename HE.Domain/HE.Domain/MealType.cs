namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MealType")]
    public partial class MealType
    {
        [Key]
        public int MealTypeID { get; set; }

        [Required]
        [Display(Name = "Meal Type")]
        public string Name { get; set; }

        [Display(Prompt = "Is a default Meal Type?")]
        public bool? IsSystemDefault { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }
    }
}
