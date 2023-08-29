using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Handlers.Queries.Customer;
using Mc2.CrudTest.Core.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public IMediator _mediatR { get; }

        public CustomerController(IMediator mediatR)
        {

            _mediatR = mediatR;

        }



        [HttpPost]
        public async Task<IActionResult> AddCutomer(AddCustomerCommand customer,CancellationToken cancellationToken)
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
        public async Task<IActionResult> GetCustomers(int count , CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(new GetCustomersQuery { count = count } , cancellationToken);
            return Ok(result);
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCustomerCommand customer, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(customer, cancellationToken);
            return Ok(result);
        }


        



    }
}
