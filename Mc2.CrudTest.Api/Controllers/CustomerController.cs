using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Handlers.Queries.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public IMediator _mediatR { get; }

        // private int takeCount  = 10;

        public CustomerController(IMediator mediatR)
        {

            _mediatR = mediatR;

        }



        [HttpPost]
        public async Task<IActionResult> AddCutomer(AddCustomerCommand customer, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(customer, cancellationToken);
            return Ok(result);
        }



        [HttpPut]
        public async Task<IActionResult> EditCustomer(EditCustomerCommand customer, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(customer, cancellationToken);
            return Ok(result);
        }




        [HttpGet]
        public async Task<IActionResult> GetCustomers(int count = 10, CancellationToken cancellationToken = default)
        {
            var result = await _mediatR.Send(new GetCustomersQuery { count = count }, cancellationToken);
            return Ok(result);
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(long customerId, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(new DeleteCustomerCommand { CustomerId = customerId }, cancellationToken);
            return Ok(result);
        }






    }
}
