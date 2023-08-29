using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Interfaces.Repository;
using Mc2.CrudTest.Core.ViewModels;
using MediatR;

namespace Mc2.CrudTest.Core.Handlers.Queries.Customer
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, RequestResponse>
    {
        public ICustomerRepository _customerRepository { get; }
        
        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<RequestResponse> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            RequestResponse requestResponse = new RequestResponse();
            try
            {
                List<GetCustomerVm> models =  await _customerRepository.GetCustomers(request.count, cancellationToken);
                return requestResponse.CustomOk(data: models);
            }
            catch (Exception)
            {
                return requestResponse.CustomError();
            }
        }
    }
}
