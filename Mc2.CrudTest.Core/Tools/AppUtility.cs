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
        public static bool PhoneNumberIsValid(string phoneNumber)
        {

            // ulong res = 0;

            try
            {
                PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber phoneNumberObject = phoneNumberUtil.Parse(phoneNumber, null);
                return phoneNumberUtil.IsValidNumberForRegion(phoneNumberObject, "US");
                //if (phoneNumberUtil.IsValidNumberForRegion(phoneNumberObject, "US"))
                //{
                //    res = ulong.Parse(phoneNumberObject.NationalNumber.ToString());
                //}
                //else
                //    res = 0;

            }
            catch (NumberParseException)
            {
                //res = 0;
                // Handle parsing errors here.

                return false;
            }

            //return res;

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
