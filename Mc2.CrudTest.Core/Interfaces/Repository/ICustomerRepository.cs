using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Domains;
using Mc2.CrudTest.Core.ViewModels;

namespace Mc2.CrudTest.Core.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<List<GetCustomerVm>> GetCustomers(int count, CancellationToken cancellationToken);
        Task Add(AddCustomerCommand request, CancellationToken cancellationToken);
        Task Edit(EditCustomerCommand customer, CancellationToken cancellationToken);
        Task DeleteById(long id, CancellationToken cancellationToken);
        Task<GetCustomerVm> GetById(long id, CancellationToken cancellationToken);
    }
}
