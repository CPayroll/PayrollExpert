using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayrollExpertApp.Data
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Operating As")]
        public string OperatingName { get; set; }

        [Required]
        [StringLength(9)]
        [MinLength(9)]
        [Display(Name = "CBA Business Number")]
        public string CBABusinessNumber { get; set; }

        [Display(Name = "Registration Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Mailing Address Same As Head Office Address")]
        public bool MailingAddressSameAsHeadOfficeAddress { get; set; }

        [StringLength(100)]
        [Display(Name = "Website URL")]
        public string WebsiteURL { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        [Display(Name = "Signing Officer")]
        public string SigningOfficer { get; set; }

        [StringLength(100)]
        public string Directors { get; set; }

        public ICollection<Person> ContactPeople { get; set; } = new List<Person>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<ShareHolder> ShareHolders { get; set; } = new List<ShareHolder>();
    }
}