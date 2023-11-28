using FluentValidation;
using Mc2.CrudTest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Dtos.Customer.Validator
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(x => x.Firstname)
                .NotEmpty()
                .NotNull()
                .WithMessage(AppConsts.EnterMessage);


            RuleFor(x => x.Lastname)
                .NotEmpty()
                .NotNull()
                .WithMessage(AppConsts.EnterMessage);



            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .NotNull()
                .WithMessage(AppConsts.EnterMessage);



            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage(AppConsts.EnterMessage)
                .Must(AppUtility.PhoneNumberIsValid)
                .WithMessage(AppConsts.EnterValidPhoneNumber);



            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(AppConsts.EnterMessage)
                .EmailAddress()
                .WithMessage(AppConsts.EnterValidEmailAddress);


            RuleFor(x => x.BankAccountNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage(AppConsts.EnterMessage)
                .Must(AppUtility.IbanIsValid)
                .WithMessage(AppConsts.EnterValidIBAN);


        }
    }
}
