using System;
using System.ComponentModel.DataAnnotations;

namespace PayrollExpertApp.Data
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Type { get; set; }

        [MaxLength(70)]
        public string AddressLine1 { get; set; }

        [MaxLength(70)]
        public string AddressLine2 { get; set; }

        [MaxLength(70)]
        public string AddressLine3 { get; set; }

        [MaxLength(70)]
        public string City { get; set; }

        [MaxLength(10)]
        public string Province { get; set; }

        [MaxLength(10)]
        public string Country { get; set; }

        [MaxLength(15)]
        public string PostalCode { get; set; }
    }
}