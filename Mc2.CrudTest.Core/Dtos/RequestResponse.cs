using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Dtos
{
    public class RequestResponse
    {
        public object data { get; set; }
        public string message { get; set; } = "Ok";
        public int status { get; set; } = 200;



        public RequestResponse CustomOk(object data = null , string message = "")
        {
            return new RequestResponse
            {
                data = data,
                message = (message != "" ? message : "OK"),
                status = 200
            };
        }


        public RequestResponse CustomError(object data = null, string message = "")
        {
            return new RequestResponse
            {
                data = data,
                message = (message != "" ? message : "Error"),
                status = 500
            };
        }


      


    }
}
