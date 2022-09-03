using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Report.Dto
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public int PlateNo { get; set; }
        public int VehicleTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifiedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
