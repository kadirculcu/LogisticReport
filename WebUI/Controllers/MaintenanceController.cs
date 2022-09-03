using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.IService;
using Entities.Report.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/maintenance")]
    [Authorize]
    public class MaintenanceController : Controller
    {
        private readonly IMaintenanceService _maintenanceService;      
        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpGet]
        [Route("GetMaintenance")]
        [AllowAnonymous]
        public IActionResult GetMaintenance([FromQuery] int id)
        {
            return Ok(_maintenanceService.GetMaintenance(id));
        }
        [HttpPost]
        [Route("AddMaintenance")]
        public IActionResult AddMaintenance([FromBody] MaintenanceDto maintenance)
        {
            _maintenanceService.AddMaintenance(maintenance);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteMaintenance")]
        public IActionResult DeleteMaintenance([FromQuery] int id)
        {
            _maintenanceService.DeleteMaintenance(id);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateMaintenance")]
        public IActionResult UpdateMaintenance([FromBody] MaintenanceDto maintenance)
        {
            _maintenanceService.UpdateMaintenance(maintenance);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllMaintenance")]
     //   [AllowAnonymous]
        public IActionResult GetAllMaintenance()
        {           
            return Ok(_maintenanceService.GetAllMaintenance());
        }
        [HttpGet]
        [Route("G")]
        [AllowAnonymous]
        public IActionResult G()
        {
            return Ok(_maintenanceService.G());
        }
    }
}
