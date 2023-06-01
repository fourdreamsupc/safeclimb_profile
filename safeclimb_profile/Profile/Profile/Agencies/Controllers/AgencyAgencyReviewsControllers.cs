using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace Go2Climb.API.Agencies.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/agencies/{agencyId}/agencyreviews")]
    public class AgencyAgencyReviewsControllers : ControllerBase
    {
        //private readonly IAgencyReviewService _agencyReviewService;
        private readonly IMapper _mapper;

        public AgencyAgencyReviewsControllers(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}