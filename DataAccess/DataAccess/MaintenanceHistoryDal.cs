using Core.DataAccess.EntityFrameworkRepository;
using DataAccess.IDataAccess;
using Entities.Report.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccess
{
    public class MaintenanceHistoryDal: EntityFrameworkRepository<MaintenanceHistory>, IMaintenanceHistoryDal
    {
        public MaintenanceHistoryDal(DbContext dbContext) : base(dbContext)
        { 

        }
    }
}
