using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Data.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.HasQueryFilter(a => !a.IsDeleted);


            builder.HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth })
           .IsUnique(true);


            builder.HasIndex(c => c.Email)
           .IsUnique(true);

        }
    }

}
