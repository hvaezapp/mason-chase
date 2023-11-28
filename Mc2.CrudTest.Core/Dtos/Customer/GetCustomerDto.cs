using Mc2.CrudTest.Core.Dtos.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Dtos.Customer
{
    public class GetCustomerDto : CustonerDto
    {
        public long Id { get; set; }
    }
}
