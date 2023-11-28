using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data
{
    public class CrudDbContext : DbContext
    {

        public CrudDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }

        public DbSet<Customer> Customers { get; set; }
    }


}
