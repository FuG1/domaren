﻿using domaren.realstate.BLL.Contracts;
using domaren.realstate.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace domaren.realestate.Controllers
{
    [ApiController]
    [Route("api/user")]
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
}