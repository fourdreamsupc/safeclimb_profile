 using AutoMapper;
using Go2Climb.API.Agencies.Domain.Models;
using Go2Climb.API.Resources;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Customers.Resources;
 
namespace Go2Climb.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAgencyResource, Agency>();
            CreateMap<SaveCustomerResourse, Customer>();
        }
    }
}