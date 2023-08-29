using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Interfaces.Repository;
using Mc2.CrudTest.Core.Utility;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneNumbers;

namespace Mc2.CrudTest.Core.Handlers.Commands.Customer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, RequestResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<AddCustomerCommandHandler> _logger;

        public AddCustomerCommandHandler(ICustomerRepository customerRepository,
                                         ILogger<AddCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<RequestResponse> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            RequestResponse response = new RequestResponse();

            try
            {
                //ulong validationResult = AppUtility.GetPhoneNumberValidation(request.PhoneNumber);

                if (AppUtility.PhoneNumberIsValid(request.PhoneNumber))
                {

                    if (AppUtility.IbanIsValid(request.BankAccountNumber))
                    {
                        //request.PhoneNumber = validationResult.ToString();
                        await _customerRepository.Add(request, cancellationToken);

                        return response.CustomOk();

                    }else
                        return response.CustomError(message: "IBAN invalid");


                }
                return response.CustomError(message: "PhoneNumber invalid");

            }
            catch (Exception ex)
            {

                _logger.Log(LogLevel.Error , ex.ToString());

                return response.CustomError();

                //return response.CustomError(message:ex.InnerException.Message);
                //return response.CustomError(AppConsts.OperationFail);
            }

        }


      

    }
}
