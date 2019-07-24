using System;
using CarpoolManagement.Common.Interfaces;
using CarpoolManagement.Common.Models;
using CarpoolManagement.DAL.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace CarpoolManagement.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private CarpoolManagementContext context;

        public EmployeeRepository(CarpoolManagementContext context)
        {
            this.context = context;
        }

        public void Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Edit(Employee employee)
        {
            context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Employee employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public Employee FindById(int id)
        {
            var result = (from r in context.Employees where r.Id == id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
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

        public IEnumerable<Employee> FindAllAvailableEmployees(List<TravelPlan> travelPlans)
        {
            List<int> ids = travelPlans.Select(x => x.Id).ToList();

            var employeeTravelPlans = (
                from r in context.EmployeeTravelPlans
                where (ids.Contains(r.TravelPlanId))
                select r
            );

            List<int> employeeIds = employeeTravelPlans.Select(x => x.EmployeeId).ToList();

            var result = (
                from r in context.Employees
                where (!employeeIds.Contains(r.Id))
                select r
            );

            return result;
        }

        public IEnumerable<Employee> FindByIds(List<int> ids)
        {
            List<Employee> result = new List<Employee>();
            foreach (var id in ids)
            {
                var employee = (from r in context.Employees where r.Id == id select r).FirstOrDefault();
                result.Add(employee);
            }
            return result;
        }
    }
}
