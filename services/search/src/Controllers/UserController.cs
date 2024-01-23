﻿using IdentityServer.Protos;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Search.API.Controllers
{
    [ApiController]
    [Route("api/Search")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("FindUsers")]
        public async Task<IActionResult> FindUsers(string name)
        {
            var response = await _userService.GetUsers();

            var users = response.Users.Where(u => u.Name.Contains(name)).ToList();

            return Ok(users);
        }
    }
}
