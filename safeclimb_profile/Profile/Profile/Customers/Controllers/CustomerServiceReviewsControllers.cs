using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Go2Climb.API.Customers.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/customers/{customerId}/servicereviews")]
    public class CustomerServiceReviewsControllers : ControllerBase
    {
        private readonly IMapper _mapper;

        public CustomerServiceReviewsControllers( IMapper mapper)
        {
            _mapper = mapper;
        }
    }
    
}