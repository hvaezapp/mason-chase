
using Cms.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cms.Infrastructure.Data
{
    public class CrudDbContext : DbContext
    {
       
        public CrudDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        public DbSet<Customer> Posts { get; set; }

    }

}
