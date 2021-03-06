﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollExpertApp.Data
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        //Foreign key for Person
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        //Foreign key for Company
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [Required]
        [MaxLength(10)]
        public string Type { get; set; }

        [Display(Name = "Address Line 1")]
        [MaxLength(70)]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [MaxLength(70)]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        [MaxLength(70)]
        public string AddressLine3 { get; set; }

        [Required]
        [MaxLength(70)]
        public string City { get; set; }

        [MaxLength(10)]
        public string Province { get; set; }

        [MaxLength(10)]
        public string Country { get; set; }

        [Display(Name = "Postal Code")]
        [MaxLength(15)]
        public string PostalCode { get; set; }
    }
}