using AutoMapper;
using Go2Climb.API.Agencies.Domain.Models;
using Go2Climb.API.Agencies.Resources;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Customers.Resources;

namespace Go2Climb.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Agency, AgencyResource>();
            //<Agency, AuthenticateResponse>();
            CreateMap<Customer, CustomerResource>();
            //CreateMap<Customer, AuthenticateResponse>();
        }
    }
}