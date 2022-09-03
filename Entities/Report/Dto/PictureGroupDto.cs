using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Report.Dto
{
    public class PictureGroupDto
    {
        public int Id { get; set; }
        public string PictureImage { get; set; } //text tanımlanacak
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifiedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
