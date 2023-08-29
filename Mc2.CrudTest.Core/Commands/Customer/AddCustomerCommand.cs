using Mc2.CrudTest.Core.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Commands.Customer
{
    public class AddCustomerCommand : IRequest<RequestResponse>
    {

        [Required]
        public string Firstname { get; set; }


        [Required]
        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Phone]
        public ulong PhoneNumber { get; set; }

        [Required , EmailAddress]
        public string Email { get; set; }


        [Required , RegularExpression(@"^([A-Z]{2}[ \-]?[0-9]{2})(?=(?:[ \-]?[A-Z0-9]){9,30}$)((?:[ \-]?[A-Z0-9]{3,5}){2,7})([ \-]?[A-Z0-9]{1,3})?$")]
        public string BankAccountNumber { get; set; }
    }




  
}
