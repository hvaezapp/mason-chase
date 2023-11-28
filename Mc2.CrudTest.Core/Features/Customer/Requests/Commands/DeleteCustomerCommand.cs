using FluentValidation;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Features.Customer.Requests.Commands
{
    public class DeleteCustomerCommand : IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }

    }

}