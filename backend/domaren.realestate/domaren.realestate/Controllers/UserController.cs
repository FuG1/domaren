using domaren.realstate.Domain.Contracts;
using domaren.realstate.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace domaren.realestate.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public User GetUser(int id)
    {
        return _userService.GetUser(id);
    }

    [HttpPost]
    public int SaveUser(User user)
    {
        return _userService.SaveUser(user);
    }
}
