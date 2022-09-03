using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.IService;
using Entities.Report.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/PictureGroupDto")]
    public class PictureGroupController : Controller
    {
        private readonly IPictureGroupService _pictureGroupService;
        public PictureGroupController(IPictureGroupService pictureGroupService)
        {
            _pictureGroupService = pictureGroupService;
        }
        [HttpGet]
        [Route("GetPictureGroup")]
        public IActionResult GetPictureGroup([FromQuery] int id)
        {
            return Ok(_pictureGroupService.GetPictureGroup(id));
        }
        [HttpPost]
        [Route("AddPictureGroup")]
        public IActionResult AddPictureGroup([FromBody] PictureGroupDto pictureGroupDto)
        {
            _pictureGroupService.AddPictureGroup(pictureGroupDto);
            return Ok();
        }
        [HttpPost]
        [Route("DeletePictureGroup")]
        public IActionResult DeletePictureGroup([FromQuery] int id)
        {
            _pictureGroupService.DeletePictureGroup(id);
            return Ok();
        }
        [HttpPost]
        [Route("UpdatePictureGroup")]
        public IActionResult UpdatePictureGroup([FromBody] PictureGroupDto pictureGroupDto)
        {
            _pictureGroupService.UpdatePictureGroup(pictureGroupDto);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllPictureGroup")]
        public IActionResult GetAllPictureGroup()
        {
            return Ok(_pictureGroupService.GetAllPictureGroup());
        }
    }
}
