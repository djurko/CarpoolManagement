using System;
using CarpoolManagement.Common.Interfaces;
using CarpoolManagement.Common.Models;
using CarpoolManagement.DAL.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace CarpoolManagement.DAL.Repositories
{
    public class CarpoolRepository : ICarpoolRepository
    {
        private CarpoolManagementContext context;

        public CarpoolRepository(CarpoolManagementContext context)
        {
            this.context = context;
        }

        public void Add(Carpool carpool)
        {
            context.Carpools.Add(carpool);
            context.SaveChanges();
        }

        public void Edit(Carpool carpool)
        {
            context.Entry(carpool).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Carpool carpool = context.Carpools.Find(id);
            context.Carpools.Remove(carpool);
            context.SaveChanges();
        }

        public Carpool FindById(int id)
        {
            var result = (from r in context.Carpools where r.Id == id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<Carpool> GetCarpools()
        {
            return context.Carpools;
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

        public bool IsUniquePlates(string plates, int id)
        {
            var result = (
                from r in context.Carpools
                where (r.Plates.Equals(plates) && r.Id != id)
                select r
            );
            return !result.Any();
        }

        public IEnumerable<Carpool> FindAllAvailableCarpools(List<TravelPlan> travelPlans)
        {
            List<int> ids = travelPlans.Select(x => x.CarId).ToList();
            var result = (
                from r in context.Carpools
                where (!ids.Contains(r.Id))
                select r
            );
            return result;
        }
    }
}
