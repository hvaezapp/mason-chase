using Mc2.CrudTest.Core.Interfaces.Repository;
using Mc2.CrudTest.Core.Commands.Customer;
using MediatR;

namespace Mc2.CrudTest.Core.Handlers.Commands.Customer
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommond, AddCustomerResponse>
    {
        public ICustomerRepository _customerRepository { get; }

        public AddCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<AddCustomerResponse> Handle(AddCustomerCommond request, CancellationToken cancellationToken)
        {
            
            return new AddCustomerResponse { Id = await _customerRepository.Add(request, cancellationToken) };
        }
    }
}
