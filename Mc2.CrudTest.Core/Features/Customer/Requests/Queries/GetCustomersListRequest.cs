using Mc2.CrudTest.Core.Dtos;
using MediatR;

namespace Mc2.CrudTest.Core.Features.Customer.Requests.Queries
{
    public class GetCustomersListRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; }
    }
}
