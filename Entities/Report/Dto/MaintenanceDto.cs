using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Report.Dto
{
    public class MaintenanceDto
    {
        public int Id { get; set; }
        public int VehicleID { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public int PictureGroupId { get; set; }
        public DateTime ExpectedTimeToFix { get; set; }
        public int ResponsibleUserId { get; set; }
        public string LocationLongitude { get; set; }
        public string LocatiLatitude { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
