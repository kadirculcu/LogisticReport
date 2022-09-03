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
    public class StatusService : IStatusService
    {
        private IStatusDal _statusDal;
        public StatusService(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }
        public void AddStatus(StatusDto statusDto)
        {
            Status status = new Status()
            {
                CreateDate = statusDto.CreateDate,
                CreatedBy = statusDto.CreatedBy,
                IsDeleted = statusDto.IsDeleted,
                ModifiedBy = statusDto.ModifiedBy,
                ModifyDate = statusDto.ModifyDate,
                Name=statusDto.Name           
            };
            _statusDal.Add(status);
        }

        public void DeleteStatus(int id)
        {
            Status status = _statusDal.Get(x => x.Id == id);
            _statusDal.Delete(status);
        }

        public List<StatusDto> GetAllStatus(Expression<Func<Status, bool>> condition = null)
        {
            List<Status> statusList = _statusDal.GetList(condition);
            return statusList.Select(x => new StatusDto() {
                CreateDate = x.CreateDate,
                CreatedBy = x.CreatedBy,
                IsDeleted = x.IsDeleted,
                ModifiedBy = x.ModifiedBy,
                ModifyDate = x.ModifyDate,
                Name = x.Name
            }).ToList();
        }

        public StatusDto GetStatus(int id)
        {
            Status status = _statusDal.Get(x => x.Id == id);
            StatusDto statusDto = new StatusDto()
            {
                CreateDate = status.CreateDate,
                CreatedBy = status.CreatedBy,
                IsDeleted = status.IsDeleted,
                ModifiedBy = status.ModifiedBy,
                ModifyDate = status.ModifyDate,
                Name = status.Name,
                Id = status.Id
            };
            return statusDto;
        }

        public void UpdateStatus(StatusDto statusDto)
        {
            Status status = _statusDal.Get(x => x.Id == statusDto.Id);
            status.CreateDate = statusDto.CreateDate;
            status.CreatedBy = statusDto.CreatedBy;
            status.IsDeleted = statusDto.IsDeleted;
            status.ModifiedBy = statusDto.ModifiedBy;
            status.ModifyDate = statusDto.ModifyDate;
            status.Name = statusDto.Name;
            _statusDal.Update(status);
        }
    }
}
