using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {
        public IMediator _mediatR { get; }

        public CustomerController(IMediator mediatR)
        {

            _mediatR = mediatR;

        }



        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddCustomerVm customer,CancellationToken cancellationToken)
        {
            var command = new AddCustomerCommond
            {
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                DateOfBirth = customer.DateOfBirth,
                BankAccountNumber = customer.BankAccountNumber
            };

            var result = await _mediatR.Send(command, cancellationToken);
            return CustomOk(result);
        }



        // post/grtlatestposts
        //[HttpGet("GetLatestPosts")]
        //public async Task<IActionResult> GetLatestPosts()
        //{
        //    var query = new GetLatestPostsQuery();
        //    var result = await _mediatR.Send(query);
        //    return CustomOk(result);
        //}



    }
}
