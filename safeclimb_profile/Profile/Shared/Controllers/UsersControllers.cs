using AutoMapper;
using Go2Climb.API.Shared.Domain.Services;
using Microsoft.AspNetCore.Mvc;


namespace Go2Climb.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController:ControllerBase
    {
        //private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /*
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Records a user login",
            Description = "Returns the data of an application user along with a hash password that identifies it.",
            Tags = new[] {"Users"})]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);
            if (response.Email == null)
                return Ok(response);
            if (response.LastName == null)
            {
                var resourcesAgency = _mapper.Map<AuthenticateResponse, AuthenticateAgencyResponse>(response);
                return Ok(resourcesAgency);
            }
            var resourcesCustomer = _mapper.Map<AuthenticateResponse, AuthenticateCustomerResponse>(response);
            return Ok(resourcesCustomer);
        }
        */
    }
}