namespace HE.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("vHomemadeItem")]
    public partial class vHomemadeItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HomemadeItemID { get; set; }
        
        [Column(Order = 1)]
        [StringLength(100)]
        public string HomemadeItem_Name { get; set; }

        [StringLength(150)]
        public string ImageTitle { get; set; }

        [StringLength(256)]
        public string ImageFilePath { get; set; }

        public bool? DidCook { get; set; }

        public bool? IsFav { get; set; }

        public bool? IsShared { get; set; }

        [StringLength(300)]
        public string AdditionalComments { get; set; }

        public DateTime? HomemadeItem_DateCreated { get; set; }

        public DateTime? HomemadeItem_LastUpdated { get; set; }
        
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MealTypeID { get; set; }
        
        [Column(Order = 3)]
        public string MealType_Name { get; set; }

        public bool? IsSystemDefault { get; set; }

        public DateTime? MealType_DateCreated { get; set; }

        public DateTime? MealType_LastUpdated { get; set; }
        
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerProfileID { get; set; }
        
        [Column(Order = 5)]
        public bool CustomerProfile_IsActive { get; set; }

        [StringLength(100)]
        public string EmailAddress { get; set; }

        public string PasswordHash { get; set; }
        
        [Column(Order = 6)]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Column(Order = 7)]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
