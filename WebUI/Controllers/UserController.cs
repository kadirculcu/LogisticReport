using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.IService;
using Entities.Report.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser([FromQuery] int id)
        {
            return Ok(_userService.GetUser(id));
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] UserDto userDto)
        {
            _userService.AddUser(userDto);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteUser")]
        public IActionResult DeleteUser([FromQuery] int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserDto userDto)
        {
            _userService.UpdateUser(userDto);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetAllUser()
        {
            return Ok(_userService.GetAllUser());
        }
    }
}
