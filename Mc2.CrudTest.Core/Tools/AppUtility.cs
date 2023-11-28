using IbanNet;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Utility
{
    public static class AppUtility
    {
        public static bool PhoneNumberIsValid(ulong phoneNumber)
        {

            try
            {
                PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber phoneNumberObject = phoneNumberUtil.Parse(phoneNumber.ToString(), null);
                return phoneNumberUtil.IsValidNumberForRegion(phoneNumberObject, "US");
             

            }
            catch (NumberParseException)
            {
               

                return false;
            }

           

        }



        public static bool IbanIsValid(string iban)
        {
            try
            {
                var validator = new IbanValidator();
                var validationResult =  validator.Validate(iban);

                return (validationResult != null ? validationResult.IsValid : false);
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
