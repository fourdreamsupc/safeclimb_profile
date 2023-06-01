using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Go2Climb.API.Customers.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/customers/{customerId}/agencyreviews")]
    public class CustomerAgencyReviewsControllers : ControllerBase
    {
        private readonly IMapper _mapper;

        public CustomerAgencyReviewsControllers(IMapper mapper)
        {
            _mapper = mapper;
        }
     
    }
}