using Core.DataAccess.EntityFrameworkRepository;
using DataAccess.IDataAccess;
using Entities.Report.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccess
{
    public class VehicleDal : EntityFrameworkRepository<Vehicle>, IVehicleDal
    {
        public VehicleDal(DbContext dbContext) : base(dbContext)
        {

        }
    }
}