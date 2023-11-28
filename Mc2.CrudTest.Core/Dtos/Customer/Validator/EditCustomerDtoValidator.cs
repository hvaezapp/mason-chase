using FluentValidation;
using Mc2.CrudTest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Dtos.Customer.Validator
{
    public class EditCustomerDtoValidator : AbstractValidator<EditCustomerDto>
    {
        public EditCustomerDtoValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage(AppConsts.EnterMessage);

            RuleFor(x => x.Firstname)
                .NotEmpty()
                .WithMessage(AppConsts.EnterMessage);

            RuleFor(x => x.Lastname)
                .NotEmpty()
                .WithMessage(AppConsts.EnterMessage);


            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage(AppConsts.EnterMessage);



            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage(AppConsts.EnterMessage)
                .Must(AppUtility.PhoneNumberIsValid)
                .WithMessage(AppConsts.EnterValidPhoneNumber);



            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(AppConsts.EnterMessage)
                .EmailAddress()
                .WithMessage(AppConsts.EnterValidEmailAddress);


            RuleFor(x => x.BankAccountNumber)
                .NotEmpty()
                .WithMessage(AppConsts.EnterMessage)
                .Must(AppUtility.IbanIsValid)
                .WithMessage(AppConsts.EnterValidIBAN);
        }
    }
}
