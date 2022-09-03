using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Report.Model
{
    public class Maintenance : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("Vehicle")]
        public int  VehicleID{ get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Description { get; set; }
        [ForeignKey("PictureGroup")]
        public int PictureGroupId { get; set; }
        public DateTime ExpectedTimeToFix { get; set; }
        public int ResponsibleUserId { get; set; }
        public string LocationLongitude { get; set; }
        public string LocatiLatitude { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual User User { get; set; }
        public virtual PictureGroup PictureGroup { get; set; }
        public virtual Status Status { get; set; }



    }

}
