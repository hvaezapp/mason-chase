using Mc2.CrudTest.Domain.Common;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Customer : BaseEntity<long>
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }



        public Customer()
        {

        }

        public Customer(string fname, string lname,
            DateTime bdate, ulong phone,
            string email, string bankNom)
        {
            Firstname = fname;
            Lastname = lname;
            DateOfBirth = bdate;
            PhoneNumber = phone;
            Email = email;
            BankAccountNumber = bankNom;
        }



        public void Edit(string fname, string lname,
           DateTime bdate, ulong phone,
           string email, string bankNom)
        {
            Firstname = fname;
            Lastname = lname;
            DateOfBirth = bdate;
            PhoneNumber = phone;
            Email = email;
            BankAccountNumber = bankNom;
        }


        public void Delete()
        {
            IsDeleted = true;
        }



        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }




    }


}
