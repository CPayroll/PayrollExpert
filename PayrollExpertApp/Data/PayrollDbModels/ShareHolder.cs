using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollExpertApp.Data
{
    public class ShareHolder
    {
        [Key]
        public int Id { get; set; }

        //Foreign key for Company
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Required]
        [Display(Name = "Common Share Percentage")]
        public double CommonSharePercentage { get; set; }

        [Required]
        [Display(Name = "Preferred Share Percentage")]
        public double PreferredSharePercentage { get; set; }

        [Required]
        [Display(Name = "Other Percentage")]
        public double OtherPercentage { get; set; }
    }
}