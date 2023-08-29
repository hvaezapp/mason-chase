using Mc2.CrudTest.Infrastructure.Data.Entities;
using Mc2.CrudTest.Infrastructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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


    public class BloggingContextFactory : IDesignTimeDbContextFactory<CrudDbContext>
    {
        public CrudDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CrudDbContext>();
            optionsBuilder.UseSqlServer(@"data source=.;initial catalog=CrudDB;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True");


            return new CrudDbContext(optionsBuilder.Options);
        }
    }

}
