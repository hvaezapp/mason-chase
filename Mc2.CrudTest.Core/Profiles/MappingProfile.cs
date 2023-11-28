using AutoMapper;
using Mc2.CrudTest.Core.Dtos.Customer;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Core.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Customer Mapping

            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, GetCustomerDto>().ReverseMap();

            #endregion






        }
    }
}
