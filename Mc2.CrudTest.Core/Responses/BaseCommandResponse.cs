using Mc2.CrudTest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Dtos
{
    public class BaseCommandResponse
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public int Page { get; set; }



        public void Success(object data = null, string message = null, List<string> errors = null, int page = 0)
        {
            IsSuccess = true;
            Message = message ?? AppConsts.Success;
            Errors = errors;
            Data = data;
            Page = page;
        }


        public void Failure(object data = null, string message = null, List<string> errors = null, int page = 0)
        {
            IsSuccess = false;
            Message = message ?? AppConsts.Failure;
            Errors = errors;
            Data = data;
            Page = page;
        }

    }
}
