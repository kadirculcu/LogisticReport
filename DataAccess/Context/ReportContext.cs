using Entities.Authentication.Model;
using Entities.Report.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class ReportContext : DbContext
    {
        public DbSet<ActionType> ActionType { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<MaintenanceHistory> MaintenanceHistory { get; set; }
        public DbSet<PictureGroup> PictureGroup { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<AuthenticationUser> AuthenticationUser { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer(@"Server=localhost;Database=Almila;Trusted_Connection=True;MultipleActiveResultSets=true;");
            optionsBuilder.UseNpgsql(@"host=localhost;database=LogisticReport;user id=postgres;password=1234;");
            optionsBuilder.UseLazyLoadingProxies();    //lazyload için gerekli
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}