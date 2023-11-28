using Mc2.CrudTest.Infrastructure.Persistence.Repositories;
using Mc2.CrudTest.Core.Contracts.Persistence;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<CrudDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("SqlServer"));
            });


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();


            return services;
        }
    }
}
