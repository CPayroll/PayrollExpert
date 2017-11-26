using System;
using System.Collections.Generic;
using System.Linq;
using PayrollExpertApp.Data;

namespace PayrollExpertApp
{
    public static class Utilities
    {
        public static dynamic GetDropDownSource(PayrollDbContext context, string type, bool addInitial = false)
        {
            var list = context.DropdownList.Where(x => x.Type == type).ToList();
            if (addInitial)
                list.Insert(0, new DropdownListItem { Id = Guid.NewGuid(), Type = type, Text = "Please select", Value = "" });

            return list;
        }
    }
}