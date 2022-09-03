using Entities.Report.Dto;
using Entities.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.IService
{
    public interface IStatusService
    {
        List<StatusDto> GetAllStatus(Expression<Func<Status, bool>> condition = null);
        void AddStatus(StatusDto statusDto);
        void DeleteStatus(int id);
        void UpdateStatus(StatusDto statusDto);
        StatusDto GetStatus(int id);
    }
}
