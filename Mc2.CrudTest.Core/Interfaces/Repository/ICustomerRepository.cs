using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Dtos;

namespace Mc2.CrudTest.Core.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<List<GetCustomerDto>> GetCustomers(int count, CancellationToken cancellationToken);
        Task Add(AddCustomerCommand request, CancellationToken cancellationToken);
        Task Edit(EditCustomerCommand customer, CancellationToken cancellationToken);
        Task DeleteById(long id, CancellationToken cancellationToken);
        Task<GetCustomerDto> GetById(long id, CancellationToken cancellationToken);
    }
}
