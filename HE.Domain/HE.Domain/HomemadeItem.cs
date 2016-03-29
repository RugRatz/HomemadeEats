namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HomemadeItem")]
    public partial class HomemadeItem
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public HomemadeItem()
        //{
        //    Groceries = new HashSet<Grocery>();
        //    Instructions = new HashSet<Instruction>();
        //}

        [Key]
        public int HomemadeItemID { get; set; }

        public int CustomerProfileID { get; set; }

        public int MealTypeID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Maximum of 100 characters.")]
        [Display(Name = "Homemade Recipe Title",
            Prompt = "Enter a title for your homemade recipe",
            Description = "Homemade Recipe Title")]
        public string Name { get; set; }

        [StringLength(256, ErrorMessage = "Maximum of 256 characters.")]
        [Display(Name = "Homemade Recipe Image",
            Prompt = "Add an image for your homemade recipe (PNG, JPEG/JPG only)",
            Description = "Homemade Recipe Image")]
        public string ImageTitle { get; set; }

        [StringLength(256, ErrorMessage = "Maximum of 256 characters.")]
        [Display(Name = "Homemade Recipe File Location", Prompt = "Add an image for your homemade recipe (PNG, JPEG/JPG only)")]
        public string ImageFilePath { get; set; }

        [Display(Name = "I have tried this recipe at home")]
        public bool? DidCook { get; set; }

        [Display(Name = "This is a favorite recipe")]
        public bool? IsFav { get; set; }

        [Display(Name = "Share this recipe with others")]
        public bool? IsShared { get; set; }

        [StringLength(300, ErrorMessage = "Maximum of 300 characters.")]
        [Display(Name = "Additional Comments")]
        public string AdditionalComments { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreatedUTC { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? LastUpdatedUTC { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Grocery> Groceries { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Instruction> Instructions { get; set; }
    }
}
