using CarpoolManagement.Common.Interfaces;
using CarpoolManagement.Common.Models;
using CarpoolManagement.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarpoolManagement.DAL.Repositories
{
    public class EmployeeTravelPlanRepository : IEmployeeTravelPlanRepository
    {
        private CarpoolManagementContext context;

        public EmployeeTravelPlanRepository(CarpoolManagementContext context)
        {
            this.context = context;
        }
        public void Add(EmployeeTravelPlan employeeTravelPlan)
        {
            context.EmployeeTravelPlans.Add(employeeTravelPlan);
            context.SaveChanges();
        }

        public void Edit(EmployeeTravelPlan employeeTravelPlan)
        {
            context.Entry(employeeTravelPlan).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            EmployeeTravelPlan employeeTravelPlan = context.EmployeeTravelPlans.Find(id);
            context.EmployeeTravelPlans.Remove(employeeTravelPlan);
            context.SaveChanges();
        }

        public EmployeeTravelPlan FindById(int id)
        {
            var result = (from r in context.EmployeeTravelPlans where r.Id == id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<EmployeeTravelPlan> GetEmployeeTravelPlans()
        {
            return context.EmployeeTravelPlans;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
