using FluentValidation;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Utility;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Core.Commands.Customer
{
    public class AddCustomerCommand : IRequest<RequestResponse>
    {

        //[Required]
        public string Firstname { get; set; }


        // [Required]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        //[Required]
        public string PhoneNumber { get; set; }


        //[Required , EmailAddress]
        public string Email { get; set; }


        //[Required]
        public string BankAccountNumber { get; set; }
    }


    // AddCustomerCommand Validation
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator()
        {
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
