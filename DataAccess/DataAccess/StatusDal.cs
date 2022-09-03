using Core.DataAccess.EntityFrameworkRepository;
using DataAccess.IDataAccess;
using Entities.Report.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccess
{
    public class StatusDal : EntityFrameworkRepository<Status>, IStatusDal
    {
        public StatusDal(DbContext dbContext) : base(dbContext)
        {

        }
    }
}