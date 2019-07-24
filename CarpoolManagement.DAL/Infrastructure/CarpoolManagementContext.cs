using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CarpoolManagement.Common.Models;

namespace CarpoolManagement.DAL.Infrastructure
{
    public class CarpoolManagementContext : DbContext
    {
        public CarpoolManagementContext() : base("CarpoolManagementContext")
        {
        }

        public DbSet<Carpool> Carpools { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TravelPlan> TravelPlans { get; set; }
        public DbSet<EmployeeTravelPlan> EmployeeTravelPlans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Carpool>()
            //    .HasIndex(entity => entity.Plates)
            //    .IsUnique(true);
        }
    }
}
