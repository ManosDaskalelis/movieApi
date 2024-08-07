﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTO;
using MovieAPI.Services;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IConfiguration _configuration;

        public UserController(IApplicationService applicationService, IConfiguration configuration)
        {
            _applicationService = applicationService;
            _configuration = configuration;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO)
        {
            var response = await _applicationService.UserService.LogIn(loginDTO);
            if (response == null)
            {
                return BadRequest();
            }
            string token = _applicationService.UserService.CreateToken(response, _configuration.GetSection("key"));
            return Ok(token);
        }
    }
}