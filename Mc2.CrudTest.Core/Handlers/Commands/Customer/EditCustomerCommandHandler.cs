using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Interfaces.Repository;
using MediatR;

namespace Mc2.CrudTest.Core.Handlers.Commands.Customer
{
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, RequestResponse>
    {
        public ICustomerRepository _customerRepository { get; }

        public EditCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<RequestResponse> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            RequestResponse response = new RequestResponse();

            try
            {

                await _customerRepository.Edit(request, cancellationToken);

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
