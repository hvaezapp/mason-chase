using Mc2.CrudTest.Core.Contracts.Persistence;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Features.Customer.Requests.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Core.Features.Customer.Handlers.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, BaseCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository,
                                     ILogger<DeleteCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<BaseCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new BaseCommandResponse();

            try
            {
                var customer = await _customerRepository.GetByIdAsync(request.Id,cancellationToken);

                customer.Delete();
               
                await _customerRepository.SaveChanges(cancellationToken);

                response.Success();

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.ToString());
                response.Failure(message : ex.Message);
                
            }

            return response;

        }



    }
}
