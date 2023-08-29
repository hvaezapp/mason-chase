using Mc2.CrudTest.Core.Dtos;
using MediatR;

namespace Mc2.CrudTest.Core.Handlers.Queries.Customer
{
    public class GetCustomersQuery : IRequest<RequestResponse>
    {
        public int count { get; set; }
    }
}
