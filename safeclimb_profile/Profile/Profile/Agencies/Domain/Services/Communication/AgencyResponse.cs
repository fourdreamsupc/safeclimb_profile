using Go2Climb.API.Agencies.Domain.Models;
using Go2Climb.API.Shared.Domain.Services.Communication;

namespace Go2Climb.API.Agencies.Domain.Services.Communication
{
    public class AgencyResponse : BaseResponse<Agency>
    {
        //UNHAPPY
        public AgencyResponse(string message) : base(message)
        {
            
        }
        //HAPPY
        public AgencyResponse(Agency resource) : base(resource)
        {
            
        }
    }
}