using FluentValidation;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Commands.Customer
{
    public class DeleteCustomerCommand : IRequest<RequestResponse>
    {

        //[Required]
        public long Id { get; set; }
        
    }


    // DeleteCustomerCommand Validation
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage(AppConsts.EnterMessage);

        }

    }

}