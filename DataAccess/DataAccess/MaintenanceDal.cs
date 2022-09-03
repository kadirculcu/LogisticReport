using Core.DataAccess.EntityFrameworkRepository;
using DataAccess.IDataAccess;
using Entities.Report.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.DataAccess
{
    public class MaintenanceDal : EntityFrameworkRepository<Maintenance>, IMaintenanceDal
    {
        public MaintenanceDal(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
