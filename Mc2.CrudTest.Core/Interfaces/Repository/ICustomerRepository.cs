using Mc2.CrudTest.Core.Commands.Customer;

namespace Mc2.CrudTest.Core.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        //Task<List<Customer>> GetCustomers(int count);
        Task<long> Add(AddCustomerCommond request, CancellationToken cancellationToken);
        //Task<long> Edit(Customer customer);
        //Task<long> Delete(Customer customer);
    }
}
