using domaren.realestate.API.Auth;
using domaren.realestate.API.Requests;
using domaren.realstate.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace domaren.realestate.API.Controllers;

    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController : ControllerBase
    {
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
        {
        _authService = authService;
        }

    [HttpPost("auth")]
    public IActionResult AuthUser([FromBody]AuthRequest request)
    {
        var claims = _authService.AuthUser(request.login, request.password);
        if (claims != null) 
        {
            var token = JwtTokenProvider.GetToken(claims);

            var response = new
            {
                access_token = token,
                username = claims.Name
            };

            return new JsonResult(response);
        }

        return Unauthorized();
    }
}
