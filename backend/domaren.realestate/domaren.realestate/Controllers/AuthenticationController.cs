using domaren.realstate.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace domaren.realestate.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }


    }
}
