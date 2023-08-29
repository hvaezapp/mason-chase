using Mc2.CrudTest.Core.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Commands.Customer
{
    public class EditCustomerCommand : AddCustomerCommand ,  IRequest<RequestResponse> 
    {
        public long Id { get; set; }
      
    }




  
}
