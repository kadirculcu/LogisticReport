using Core.DataAccess;
using Entities.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.IDataAccess
{
    public interface IMaintenanceDal : IEntityRepository<Maintenance>
    {

    }
}
