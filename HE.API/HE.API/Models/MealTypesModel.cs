using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace HE.API.Models
{
    //Model returned by MealTypesController actions
    public class MealTypesModel
    {
        [Required]
        public int MealTypeID { get; set; }

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
    
    public class MealTypesList
    {
        public List<MealTypesModel> MealTypesItemList;
    }
}