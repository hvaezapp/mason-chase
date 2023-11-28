using FluentValidation;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Dtos.Customer;
using Mc2.CrudTest.Core.Utility;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Core.Features.Customer.Requests.Commands
{
    public class CreateCustomerCommand : IRequest<BaseCommandResponse>
    {
        public CreateCustomerDto CreateCustomerDto { get; set; }


    }





}
