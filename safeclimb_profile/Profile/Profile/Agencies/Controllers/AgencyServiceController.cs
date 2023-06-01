using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Go2Climb.API.Agencies.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/agencies/{agencyId}/services")]
    public class AgencyServiceController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AgencyServiceController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /*[HttpGet({"i"})]
        [SwaggerOperation(
            Summary = "Get Services with Offer By Agency",
            Description = "Get All Services with Offer for a given AgencyId",
            Tags = new[] {"Agencies"})]
        public async Task<IEnumerable<ServiceResource>> GetServiceWithOffByAgencyId(int agencyId)
        {
            var services = await _serviceService.ListServiceWithOfferByAgencyId(agencyId);
        }*/
    }
}