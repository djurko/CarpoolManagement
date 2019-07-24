using CarpoolManagement.Common.Interfaces;
using CarpoolManagement.Common.Models;
using CarpoolManagement.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarpoolManagement.DAL.Repositories
{
    public class TravelPlanRepository : ITravelPlanRepository
    {
        private CarpoolManagementContext context;

        public TravelPlanRepository(CarpoolManagementContext context)
        {
            this.context = context;
        }

        public void Add(TravelPlan travelPlan)
        {
            //if (FindConflictingTravelPlans(travelPlan.StartDate, travelPlan.EndDate).Count() != 0)
            //{
            //    throw new Exception("There are conflicting travel plans for this period.");
            //}

            context.TravelPlans.Add(travelPlan);
            context.SaveChanges();
        }

        public void Edit(TravelPlan travelPlan)
        {
            context.Entry(travelPlan).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            TravelPlan travelPlan = context.TravelPlans.Find(id);
            context.TravelPlans.Remove(travelPlan);
            context.SaveChanges();
        }

        public TravelPlan FindById(int id)
        {
            var result = (from r in context.TravelPlans where r.Id == id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<TravelPlan> GetTravelPlans()
        {
            return context.TravelPlans;
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

        public IEnumerable<TravelPlan> FindConflictingTravelPlans(DateTime startDate, DateTime endDate)
        {
            var result = (
                from r in context.TravelPlans
                where (startDate >= r.StartDate && startDate <= r.EndDate) ||
                      (endDate >= r.StartDate && endDate <= r.EndDate)
                select r
            );

            return result;
        }
    }
}
