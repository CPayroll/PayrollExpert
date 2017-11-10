using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollExpertApp.Data
{
    public class AccountingSetup
    {
        [Key]
        public Guid Id { get; set; }

        public string name { get; set; }

    }
}