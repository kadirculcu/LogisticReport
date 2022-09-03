using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Report.Model
{
    public class PictureGroup : IEntity
    {
        public int Id { get; set; }
        public string PictureImage { get; set; } 
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifiedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
