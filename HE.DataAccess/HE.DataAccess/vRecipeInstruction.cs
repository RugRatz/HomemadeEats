namespace HE.DataAccess
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("vRecipeInstruction")]
    public partial class vRecipeInstruction
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InstructionID { get; set; }
        
        [Column(Order = 1)]
        public string Instruction { get; set; }

        public DateTime? DateCreatedUTC { get; set; }

        public DateTime? LastUpdatedUTC { get; set; }
        
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HomemadeItemID { get; set; }
        
        [Column(Order = 3)]
        [StringLength(100)]
        public string HomemadeItem_Name { get; set; }
    }
}
