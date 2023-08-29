using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Utility
{
    public static class AppUtility
    {
       public static bool IsValidNumber(string aNumber)
        {
            bool result = false;
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber phoneNumber = phoneNumberUtil.Parse(aNumber, "IN");
            result = phoneNumberUtil.IsValidNumber(phoneNumber);
            return result;
        }
    }
}
