using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayrollExpertApp.Data
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}