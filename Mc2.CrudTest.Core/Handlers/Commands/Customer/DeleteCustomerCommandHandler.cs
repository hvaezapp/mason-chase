using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Interfaces.Repository;
using MediatR;

namespace Mc2.CrudTest.Core.Handlers.Commands.Customer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, RequestResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<RequestResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            RequestResponse response = new RequestResponse();

            try
            {

                await _customerRepository.DeleteById(request.Id, cancellationToken);

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
