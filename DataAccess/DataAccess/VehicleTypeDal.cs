using Core.DataAccess.EntityFrameworkRepository;
using DataAccess.IDataAccess;
using Entities.Report.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccess
{
    public class VehicleTypeDal : EntityFrameworkRepository<VehicleType>, IVehicleTypeDal
    {
        public VehicleTypeDal(DbContext dbContext) : base(dbContext)
        {

        }
    }
}