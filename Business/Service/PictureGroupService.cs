using Business.IService;
using DataAccess.IDataAccess;
using Entities.Report.Dto;
using Entities.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Service
{
    public class PictureGroupService : IPictureGroupService
    {
        private IPictureGroupDal _pictureGroupDal;
        public PictureGroupService(IPictureGroupDal pictureGroupDal)
        {
            _pictureGroupDal = pictureGroupDal;
        }
        public void AddPictureGroup(PictureGroupDto pictureGroupDto)
        {
            PictureGroup pictureGroup = new PictureGroup() 
            {
                CreateDate=pictureGroupDto.CreateDate,
                CreatedBy=pictureGroupDto.CreatedBy,
                IsDeleted=pictureGroupDto.IsDeleted,
                ModifiedBy= pictureGroupDto.ModifiedBy,
                ModifyDate=pictureGroupDto.ModifyDate,
                PictureImage=pictureGroupDto.PictureImage
            };
            _pictureGroupDal.Add(pictureGroup);
        }

        public void DeletePictureGroup(int id)
        {
            PictureGroup pictureGroup = _pictureGroupDal.Get(p => p.Id == id);
            _pictureGroupDal.Delete(pictureGroup);
        }

        public List<PictureGroupDto> GetAllPictureGroup(Expression<Func<PictureGroup, bool>> condition = null)
        {
            List<PictureGroup> pictureGroupList = _pictureGroupDal.GetList();
            return pictureGroupList.Select(x => new PictureGroupDto()
            {
                Id = x.Id,
                CreateDate = x.CreateDate,
                CreatedBy = x.CreatedBy,
                IsDeleted = x.IsDeleted,
                ModifiedBy = x.ModifiedBy,
                ModifyDate = x.ModifyDate,
                PictureImage = x.PictureImage
            }).ToList();
        }

        public PictureGroupDto GetPictureGroup(int id)
        {
            PictureGroup pictureGroup = _pictureGroupDal.Get(p => p.Id == id);
            PictureGroupDto pictureGroupDto = new PictureGroupDto()
            {
                CreateDate = pictureGroup.CreateDate,
                CreatedBy = pictureGroup.CreatedBy,
                IsDeleted = pictureGroup.IsDeleted,
                ModifiedBy = pictureGroup.ModifiedBy,
                ModifyDate = pictureGroup.ModifyDate,
                PictureImage = pictureGroup.PictureImage
            };
            return pictureGroupDto;
        }

        public void UpdatePictureGroup(PictureGroupDto pictureGroupDto)
        {
            PictureGroup pictureGroup = _pictureGroupDal.Get(p => p.Id == pictureGroupDto.Id);
            pictureGroup.CreateDate = pictureGroupDto.CreateDate;
            pictureGroup.CreatedBy = pictureGroupDto.CreatedBy;
            pictureGroup.IsDeleted = pictureGroupDto.IsDeleted;
            pictureGroup.ModifiedBy = pictureGroupDto.ModifiedBy;
            pictureGroup.ModifyDate = pictureGroupDto.ModifyDate;
            pictureGroup.PictureImage = pictureGroupDto.PictureImage;
            _pictureGroupDal.Update(pictureGroup);
        }
    }
}
