using Mc2.CrudTest.Infrastructure.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Infrastructure.Data.Entities
{
    public class Customer : BaseEntity<long>
    {
  
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ulong PhoneNumber { get; set; }

        public string Email { get; set; }

        public string BankAccountNumber { get; set; }

       
    }


}
