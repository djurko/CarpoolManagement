using CarpoolManagement.Common.Models;
using System.Collections.Generic;

namespace CarpoolManagement.Common.Interfaces
{
    public interface IEmployeeTravelPlanRepository
    {
        void Add(EmployeeTravelPlan employeeTravelPlan);
        void Edit(EmployeeTravelPlan employeeTravelPlan);
        void Remove(int id);
        EmployeeTravelPlan FindById(int id);
        IEnumerable<EmployeeTravelPlan> GetEmployeeTravelPlans();
        void Dispose();
    }
}
