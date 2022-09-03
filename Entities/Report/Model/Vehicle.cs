using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Report.Model
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        public int PlateNo { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        public int UserId{ get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifiedBy { get; set; }
        public int IsDeleted { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
