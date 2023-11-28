using AutoMapper;
using Mc2.CrudTest.Core.Contracts.Persistence;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Dtos.Customer;
using Mc2.CrudTest.Core.Dtos.Customer.Validator;
using Mc2.CrudTest.Core.Features.Customer.Requests.Commands;
using Mc2.CrudTest.Core.Utility;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Core.Features.Customer.Handlers.Commands
{
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EditCustomerCommandHandler> _logger;
        private readonly ICustomerRepository _customerRepository;

        public EditCustomerCommandHandler(ICustomerRepository customerRepository,
                                           ILogger<EditCustomerCommandHandler> logger,
                                           IMapper mapper)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new BaseCommandResponse();

            try
            {

                var validator = new EditCustomerDtoValidator();

                var validationResult = await validator.ValidateAsync(request.EditCustomerDto);

                if (validationResult != null)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {

                    var customer = await _customerRepository.GetByIdAsync(request.EditCustomerDto.Id , cancellationToken);
                    customer.Edit(request.EditCustomerDto.Firstname,
                                                request.EditCustomerDto.Lastname, request.EditCustomerDto.DateOfBirth,
                                                request.EditCustomerDto.PhoneNumber,
                                                request.EditCustomerDto.Email, request.EditCustomerDto.BankAccountNumber);

                    //var oldCustomer = _mapper.Map<Domain.Entities.Customer>(request.EditCustomerDto);

                    //oldCustomer = await _customerRepository.Update(oldCustomer);

                    await _customerRepository.SaveChanges(cancellationToken);

                    //response.Success(data: _mapper.Map<GetCustomerDto>(customer));

                    response.Success();

                }

            }
            catch (Exception ex)
            {

                _logger.Log(LogLevel.Error, ex.ToString());

                response.Failure(message: ex.Message);

            }

            return response;

        }



    }
}
