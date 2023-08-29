using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Interfaces.Repository;
using MediatR;

namespace Mc2.CrudTest.Core.Handlers.Commands.Customer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, RequestResponse>
    {
        public ICustomerRepository _customerRepository { get; }

        public AddCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<RequestResponse> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            RequestResponse response = new RequestResponse();

            try
            {

                //if(string.IsNullOrEmpty(request.Email) || )


                await _customerRepository.Add(request, cancellationToken);

                return response.CustomOk();

            }
            catch (Exception)
            {
                return response.CustomError();
                //return response.CustomError(AppConsts.OperationFail);
            }

        }



    }
}
