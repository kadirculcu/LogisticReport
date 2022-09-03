using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.IService;
using Entities.Report.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/Status")]
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        [HttpGet]
        [Route("GetStatus")]
        public IActionResult GetStatus([FromQuery] int id)
        {
            return Ok(_statusService.GetStatus(id));
        }
        [HttpPost]
        [Route("AddStatus")]
        public IActionResult AddStatus([FromBody] StatusDto statusDto)
        {
            _statusService.AddStatus(statusDto);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteStatus")]
        public IActionResult DeleteStatus([FromQuery] int id)
        {
            _statusService.DeleteStatus(id);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateStatus")]
        public IActionResult UpdateStatus([FromBody] StatusDto StatusDto)
        {
            _statusService.UpdateStatus(StatusDto);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllStatus")]
        public IActionResult GetAllStatus()
        {
            return Ok(_statusService.GetAllStatus());
        }
    }
}
