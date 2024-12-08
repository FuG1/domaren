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
    public ActionResult<string> AuthUser([FromBody]AuthRequest request)
    {
        var claims = _authService.AuthUser(request.login, request.password);
        if (claims != null) 
        {
            return JwtTokenProvider.GetToken(claims);
        }

        return Unauthorized();
    }
}
