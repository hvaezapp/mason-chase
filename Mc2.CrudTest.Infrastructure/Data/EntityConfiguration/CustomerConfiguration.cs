using Mc2.CrudTest.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);


            builder.HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth })
           .IsUnique(true);


            builder.HasIndex(c => c.Email)
           .IsUnique(true);

        }
    }

}
