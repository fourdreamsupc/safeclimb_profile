 using AutoMapper;
using Go2Climb.API.Agencies.Domain.Models;
using Go2Climb.API.Resources;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Customers.Resources;
 using Go2Climb.API.Customers.Services;
 using Go2Climb.API.Security.Domain.Services.Communication;

 namespace Go2Climb.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAgencyResource, Agency>();
            CreateMap<UpdateAgencyRequest, Agency>()
                .ForAllMembers(options => options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));
            
            CreateMap<SaveCustomerResourse, Customer>();
            CreateMap<RegisterCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>()
                .ForAllMembers(options => options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));
        }
    }
}