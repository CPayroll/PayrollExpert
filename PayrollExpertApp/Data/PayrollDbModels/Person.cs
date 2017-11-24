using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollExpertApp.Data
{
    public class Person
    {
        [Key]
        [Display(Name = "# Of Employee")]
        public int Id { get; set; }

        //Foreign key for Company
        [Required]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(9)]
        [MaxLength(9)]
        [Display(Name = "SIN Number")]
        public string SIN { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime Birthday { get; set; }

        [Required]
        [Display(Name = "Payroll Method")]
        public int PayrollType { get; set; }

        [Required]
        [Display(Name = "Remittance Method")]
        public int RemittanceType { get; set; }

        [Display(Name = "Contract Copied")]
        public bool ContractCopied { get; set; }

        [StringLength(500)]
        public String Comment { get; set; }

        public DateTime StartDate { get; set; }

        public virtual ShareHolder ShareHolderInfo { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}