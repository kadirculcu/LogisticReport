using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Report.Model
{
    public class MaintenanceHistory : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("Maintenance")]
        public int MaintenanceId { get; set; }
        [ForeignKey("ActionType")]
        public int ActionTypeId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifiedBy { get; set; }
        public int IsDeleted { get; set; }
        public string Text { get; set; }
        public virtual Maintenance Maintenance { get; set; }
        public virtual ActionType ActionType { get; set; }
    }
}
