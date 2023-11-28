using Mc2.CrudTest.Core.Contracts.Persistence;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CrudDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private IDbConnection _db;

        public CustomerRepository(CrudDbContext dbContext, IConfiguration configuration)
            : base(dbContext)
        {
            _dbContext = dbContext;
             _configuration = configuration;
            _db = new SqlConnection(_configuration.GetConnectionString("SqlServer"));
        }


        public async Task<IEnumerable<Customer>> GetAllWithPagingWithDapper(int skip, int take , CancellationToken cancellationToken)
        {
            try
            {
                string getAllCityQuery = $"SELECT * FROM Customers ORDER BY Id OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY";
                return await _db.QueryAsync<Customer>(getAllCityQuery);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
