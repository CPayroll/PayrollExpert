using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayrollExpertApp.Data
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string OperatingName { get; set; }
        public string CBABusinessNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool MailingAddressSameAsHeadOfficeAddress { get; set; }
        public string WebsiteURL { get; set; }
        public string Email { get; set; }
        public string SigningOfficer { get; set; }
        public string Directors { get; set; }
        public string Contr { get; set; }
        public ICollection<Person> ContactPeople { get; set; } = new List<Person>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<ShareHolder> ShareHolders { get; set; } = new List<ShareHolder>();
    }
}