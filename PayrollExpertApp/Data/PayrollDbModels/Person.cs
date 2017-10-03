using System.Collections.Generic;

namespace PayrollExpertApp.Data
{
    public class Person
    {

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}