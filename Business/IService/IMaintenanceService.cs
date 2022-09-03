using Entities.Report.Dto;
using Entities.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.IService
{
    public interface IMaintenanceService
    {
        List<MaintenanceDto> GetAllMaintenance(Expression<Func<Maintenance, bool>> condition = null);
        void AddMaintenance(MaintenanceDto maintenance);
        void DeleteMaintenance(int id);
        void UpdateMaintenance(MaintenanceDto maintenance);
        MaintenanceDto GetMaintenance(int id);
        Maintenance G();
    }
}
