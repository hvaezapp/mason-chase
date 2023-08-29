using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Interfaces.Repository;
using Mc2.CrudTest.Core.Utility;
using MediatR;

namespace Mc2.CrudTest.Core.Handlers.Commands.Customer
{
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, RequestResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public EditCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<RequestResponse> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            RequestResponse response = new RequestResponse();

            try
            {

                //ulong validationResult = AppUtility.PhoneNumberIsValid(request.PhoneNumber);

                if (AppUtility.PhoneNumberIsValid(request.PhoneNumber))
                {
                    if (AppUtility.IbanIsValid(request.BankAccountNumber))
                    {
                        //request.PhoneNumber = validationResult.ToString();
                        await _customerRepository.Edit(request, cancellationToken);

                        return response.CustomOk();

                    }
                    else
                        return response.CustomError(message: "IBAN invalid");

                }
                return response.CustomError(message: "PhoneNumber invalid");

            }
            catch (Exception)
            {
                return response.CustomError();
                //return response.CustomError(AppConsts.OperationFail);
            }

        }



    }
}
