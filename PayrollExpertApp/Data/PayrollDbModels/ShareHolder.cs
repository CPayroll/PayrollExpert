using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollExpertApp.Data
{
    public class ShareHolder
    {
        [Key]
        public int Id { get; set; }

        //Foreign key for Compay
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public string Name { get; set; }
        public string SINNumber { get; set; }
        public double CommonSharePercentage { get; set; }
        public double PreferredSharePercentage { get; set; }
        public double OtherPercentage { get; set; }
    }
}