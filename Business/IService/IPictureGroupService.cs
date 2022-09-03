using Entities.Report.Dto;
using Entities.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.IService
{
    public interface IPictureGroupService
    {
        List<PictureGroupDto> GetAllPictureGroup(Expression<Func<PictureGroup, bool>> condition = null);
        void AddPictureGroup(PictureGroupDto pictureGroupDto);
        void DeletePictureGroup(int id);
        void UpdatePictureGroup(PictureGroupDto pictureGroupDto);
        PictureGroupDto GetPictureGroup(int id);
    }
}
