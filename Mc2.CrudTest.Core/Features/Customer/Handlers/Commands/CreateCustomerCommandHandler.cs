using AutoMapper;
using Mc2.CrudTest.Core.Contracts.Persistence;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Dtos.Customer;
using Mc2.CrudTest.Core.Dtos.Customer.Validator;
using Mc2.CrudTest.Core.Features.Customer.Requests.Commands;
using MediatR;
using Microsoft.Extensions.Logging;


//using Customer = Mc2.CrudTest.Domain.Common.Entities.Customer;

namespace Mc2.CrudTest.Core.Features.Customer.Handlers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
                                           ILogger<CreateCustomerCommandHandler> logger,
                                           IMapper mapper)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new BaseCommandResponse();

            try
            {

                var validator = new CreateCustomerDtoValidator();

                var validationResult = await validator.ValidateAsync(request.CreateCustomerDto);

                if (validationResult != null)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {

                    var newCustomer = _mapper.Map<Domain.Entities.Customer>(request.CreateCustomerDto);

                    newCustomer = await _customerRepository.Create(newCustomer, cancellationToken);
                    await _customerRepository.SaveChanges(cancellationToken);


                    response.Success(data: _mapper.Map<GetCustomerDto>(newCustomer));
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
