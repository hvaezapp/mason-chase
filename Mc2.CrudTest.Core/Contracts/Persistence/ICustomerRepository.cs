using Mc2.CrudTest.Core.Application.Contracts.Persistence;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Core.Contracts.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer> , IDapperRepository<Customer>
    {
    }
}
