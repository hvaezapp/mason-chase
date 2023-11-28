using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.CrudTest.Core.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message):base(message) 
        {

        }
    }
}
