using AutoMapper;
using Mc2.CrudTest.Core.Contracts.Persistence;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Dtos.Customer;
using Mc2.CrudTest.Core.Features.Customer.Handlers.Commands;
using Mc2.CrudTest.Core.Features.Customer.Requests.Queries;
using Mc2.CrudTest.Core.Utility;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Core.Features.Customer.Handlers.Queries
{
    public class GetCustomersListRequestHandler : IRequestHandler<GetCustomersListRequest, BaseCommandResponse>
    {
        private readonly string CustomersListCacheKey = "CustomersListCacheKey";

        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<GetCustomersListRequestHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetCustomersListRequestHandler(ICustomerRepository customerRepository,
                                     ILogger<GetCustomersListRequestHandler> logger,
                                     IMapper mapper,
                                     IMemoryCache cache)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _mapper = mapper;
            _cache = cache;
        }


        public async Task<BaseCommandResponse> Handle(GetCustomersListRequest request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new BaseCommandResponse();
            try
            {
                //paging
                if (request.Page < 1)
                    request.Page = 1;


                int skip = (request.Page -  1) * AppConsts.TakeCount;


                if (_cache.TryGetValue(CustomersListCacheKey, out IEnumerable<Domain.Entities.Customer> customers))
                {

                }
                else
                {
                     //Read Via Dapper ORM
                     customers = await _customerRepository.GetAllWithPagingWithDapper(skip , AppConsts.TakeCount, cancellationToken);

                    //Read Via EF ORM
                    // customers = await _customerRepository.GetAllAsyncWithPaging(skip, AppConsts.TakeCount, cancellationToken);


                }

                var data = _mapper.Map<List<GetCustomerDto>>(customers);
                response.Success(data: _mapper.Map<List<GetCustomerDto>>(customers));


            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.ToString());

                response.Failure(message: ex.Message);
            }

            return response;
        }
    }
}
