using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Go2Climb.API.Customers.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/customers/{customerId}/hiredservices")]
    public class CustomerHiredServicesControllers : ControllerBase
    {
        
        private readonly IMapper _mapper;

        public CustomerHiredServicesControllers(IMapper mapper)
        {
            _mapper = mapper;
        }
        
    }
    
}