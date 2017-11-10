using Microsoft.EntityFrameworkCore;

namespace PayrollExpertApp.Data
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class PayrollDbContext : DbContext
    {
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options)
            : base(options)
        {
        
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AccountingSetup> AccountingSetup { get; set; }
        public DbSet<DropdownListItem> DropdownList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;Database=PayrollExpert;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        
    }
}