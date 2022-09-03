using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Authentication;
using Entities.Authentication.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            return Ok(_authenticationService.Login(loginDto));
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(LoginDto LoginDto)
        {
            _authenticationService.Register(LoginDto);
            return Ok();
        }
    }
}
