using AutoMapper;

using Go2Climb.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Go2Climb.API.Agencies.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/agencies/{agencyId}/hiredservices")]
    public class AgencyHiredServicesController : ControllerBase
    {
      
        private readonly IMapper _mapper;
        
        public AgencyHiredServicesController( IMapper mapper) {
            _mapper = mapper;
        }
    }
}