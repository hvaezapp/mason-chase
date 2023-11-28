using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Dtos.Common
{
    public class BaseDto<T>
    {
        public T Id { get; set; }
    }
}
