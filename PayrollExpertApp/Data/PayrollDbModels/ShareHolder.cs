using System.ComponentModel.DataAnnotations;

namespace PayrollExpertApp.Data
{
    public class ShareHolder
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string SINNumber { get; set; }
        public double CommonSharePercentage { get; set; }
        public double PreferredSharePercentage { get; set; }
        public double OtherPercentage { get; set; }
    }
}