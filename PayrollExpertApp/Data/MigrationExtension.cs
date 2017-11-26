using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollExpertApp.Data
{
    public static class MigrationExtension
    {
        public static void EnsureSeedData(this PayrollDbContext context)
        {
            if (!context.Database.GetPendingMigrations().Any())
            {
                if (!context.DropdownList.Any())
                {
                    context.DropdownList.AddRange(
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "Daily", Value = "1" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "Weekly", Value = "2" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "Semi-monthly", Value = "3" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "Monthly", Value = "4" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "10 Per periods a year", Value = "5" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "13 Pay periods a year", Value = "6" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "22 Pay periods a year", Value = "7" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "Weekly", Value = "8" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "Bi-weekly (27 pay periods a year)", Value = "9" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "PayrollPeriodFrequency", Text = "Annually", Value = "10" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "RemittancePeriodFrequency", Text = "Monthly", Value = "1" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "RemittancePeriodFrequency", Text = "Quarterly", Value = "2" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "RemittancePeriodFrequency", Text = "Annually", Value = "3" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "AddressType", Text = "Mailing", Value = "Mailing" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "AddressType", Text = "Shipping", Value = "Shipping" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Alberta", Value = "AB" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "British Columbia", Value = "BC" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Manitoba", Value = "MB" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "New Brunswick", Value = "NB" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Newfoundland and Labrador", Value = "NL" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Nova Scotia", Value = "NS" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Ontario", Value = "ON" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Prince Edward Island", Value = "PE" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Quebec", Value = "QC" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Saskatchewan", Value = "SK" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Northwest Territories", Value = "NT" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Nunavut", Value = "NU" },
                        new DropdownListItem { Id = Guid.NewGuid(), Type = "Provice", Text = "Yukon", Value = "YT" }

                        );

                    context.SaveChanges();
                }

                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(
                        new Company { Name = "Your company", CBABusinessNumber = "xxxxxxxxx", MailingAddressSameAsHeadOfficeAddress = true, RegistrationDate = DateTime.Now });

                    context.SaveChanges();
                }
            }
        }
    }
}
