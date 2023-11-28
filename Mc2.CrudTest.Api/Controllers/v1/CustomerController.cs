using Mc2.CrudTest.Core.Dtos.Customer;
using Mc2.CrudTest.Core.Features.Customer.Requests.Commands;
using Mc2.CrudTest.Core.Features.Customer.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers.v1
{
    [ApiVersion("1", Deprecated = false)]
    public class CustomerController : BaseController
    {
        public IMediator _mediatR { get; }

        public CustomerController(IMediator mediatR)
        {

            _mediatR = mediatR;

        }


         // Create Customer
        [HttpPost("[acttion]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(new CreateCustomerCommand { CreateCustomerDto = dto }, cancellationToken);
            return Ok(result);
        }




        // Edit Customer
        [HttpPut("[acttion]")]
        public async Task<IActionResult> Edit([FromBody] EditCustomerDto dto, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(new EditCustomerCommand { EditCustomerDto = dto }, cancellationToken);
            return Ok(result);
        }




        // Get All Customers With Paging
        [HttpGet("[acttion]/{page}")]
        public async Task<IActionResult> GetAll(int page, CancellationToken cancellationToken = default)
        {
            var result = await _mediatR.Send(new GetCustomersListRequest { Page = page }, cancellationToken);
            return Ok(result);
        }




        // Delete Customer With Id
        [HttpDelete("[acttion]/{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(new DeleteCustomerCommand { Id = id }, cancellationToken);
            return Ok(result);
        }






    }
}
