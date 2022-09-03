using Business.IService;
using DataAccess.Context;
using DataAccess.IDataAccess;
using Entities.Report.Dto;
using Entities.Report.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Service
{
    public class MaintenenceService : IMaintenanceService
    {
        private IMaintenanceDal _maintenanceDal;
        private readonly ReportContext _context;
        public MaintenenceService(IMaintenanceDal maintenanceDal, ReportContext context)
        {
            _maintenanceDal = maintenanceDal;
            _context = context;
        }
       
        public void AddMaintenance(MaintenanceDto maintenance)
        {
            Maintenance newMaintenance = new Maintenance()
            {
                CreateDate=maintenance.CreateDate,
                CreatedBy=maintenance.CreatedBy,
                Description=maintenance.Description,
                ExpectedTimeToFix=maintenance.ExpectedTimeToFix,
                IsDeleted=maintenance.IsDeleted,
                LocatiLatitude=maintenance.LocatiLatitude,
                LocationLongitude=maintenance.LocationLongitude,
                ModifiedBy=maintenance.ModifiedBy,
                ModifyDate=maintenance.ModifyDate,
                PictureGroupId=maintenance.PictureGroupId,
                ResponsibleUserId=maintenance.ResponsibleUserId,
                StatusId=maintenance.StatusId,
                UserId=maintenance.UserId,
                VehicleID=maintenance.VehicleID,              
            };
            _maintenanceDal.Add(newMaintenance);
        }

        public void DeleteMaintenance(int id)
        {
            Maintenance maintenance= _maintenanceDal.Get(x => x.Id == id);
            _maintenanceDal.Delete(maintenance);
        }

        public MaintenanceDto GetMaintenance(int id)
        {
            Maintenance maintenance = _maintenanceDal.Get(p=>p.Id==id);
            MaintenanceDto maintenanceDto = new MaintenanceDto()
            {
                CreateDate = maintenance.CreateDate,
                CreatedBy = maintenance.CreatedBy,
                Description = maintenance.Description,
                ExpectedTimeToFix = maintenance.ExpectedTimeToFix,
                IsDeleted = maintenance.IsDeleted,
                LocatiLatitude = maintenance.LocatiLatitude,
                LocationLongitude = maintenance.LocationLongitude,
                ModifiedBy = maintenance.ModifiedBy,
                ModifyDate = maintenance.ModifyDate,
                PictureGroupId = maintenance.PictureGroupId,
                ResponsibleUserId = maintenance.ResponsibleUserId,
                StatusId = maintenance.StatusId,
                UserId = maintenance.UserId,
                VehicleID = maintenance.VehicleID,
            };
            return maintenanceDto;
        }

        public void UpdateMaintenance(MaintenanceDto maintenance)
        {
            Maintenance updateMaintenance = _maintenanceDal.Get(x => x.Id == maintenance.Id);
            updateMaintenance.Id = maintenance.Id;
            updateMaintenance.CreateDate = maintenance.CreateDate;
            updateMaintenance.CreatedBy = maintenance.CreatedBy;
            updateMaintenance.Description = maintenance.Description;
            updateMaintenance.ExpectedTimeToFix = maintenance.ExpectedTimeToFix;
            updateMaintenance.IsDeleted = maintenance.IsDeleted;
            updateMaintenance.LocatiLatitude = maintenance.LocatiLatitude;
            updateMaintenance.LocationLongitude = maintenance.LocationLongitude;
            updateMaintenance.ModifiedBy = maintenance.ModifiedBy;
            updateMaintenance.ModifyDate = maintenance.ModifyDate;
            updateMaintenance.PictureGroupId = maintenance.PictureGroupId;
            updateMaintenance.ResponsibleUserId = maintenance.ResponsibleUserId;
            updateMaintenance.StatusId = maintenance.StatusId;
            updateMaintenance.UserId = maintenance.UserId;
            updateMaintenance.VehicleID = maintenance.VehicleID;
            _maintenanceDal.Update(updateMaintenance);
        }

      
        public List<MaintenanceDto> GetAllMaintenance(Expression<Func<Maintenance, bool>> condition = null)
        {
            List<Maintenance> maintenanceDtos = _maintenanceDal.GetList(condition);
            return maintenanceDtos.Select(x => new MaintenanceDto()
            {
                Id = x.Id,
                CreateDate = x.CreateDate,
                CreatedBy = x.CreatedBy,
                Description = x.Description,
                ExpectedTimeToFix = x.ExpectedTimeToFix,
                IsDeleted = x.IsDeleted,
                LocatiLatitude = x.LocatiLatitude,
                LocationLongitude = x.LocationLongitude,
                ModifiedBy = x.ModifiedBy,
                ModifyDate = x.ModifyDate,
                PictureGroupId = x.PictureGroupId,
                ResponsibleUserId = x.ResponsibleUserId,
                StatusId = x.StatusId,
                UserId = x.UserId,
                VehicleID = x.VehicleID,
            }).ToList();
        }

        public Maintenance G()
        {
            Maintenance result = new Maintenance();
            Maintenance result1 = new Maintenance();
            result1 = _context.Set<Maintenance>().FirstOrDefault();
            result = _context.Maintenance.FirstOrDefault();

          //  IStatusService statusservice = Resolve<IStatusService>(); bu çalışmamakta araştırılacak.
            //   _context.Add(result);

       //     result.Description = "bn";
             
          //   _context.Update(result);
            
            //var res= _context.Set<Maintenance>();
            using (var context = new ReportContext())
       /*     {
               var m  = context.Maintenance.ToList();
                    result = context.Maintenance.FirstOrDefault();
                result.Description = "bn";
                  //  context.Update(result);

            }*/
            return result;
        }
        
    }
}
