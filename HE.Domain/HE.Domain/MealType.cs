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

        [StringLength(256, ErrorMessage = "Maximum of 250 characters.")]
        [Display(Name = "Meal Type File Location", Prompt = "Add an image for your meal type (PNG, JPEG/JPG only)")]
        public string ImageFilePath { get; set; }

        [Display(Prompt = "Is a default Meal Type?")]
        public bool? IsSystemDefault { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }
    }
}
