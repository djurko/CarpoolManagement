using CarpoolManagement.Common.Models;
using System.Collections.Generic;

namespace CarpoolManagement.Common.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Edit(Employee employee);
        void Remove(int id);
        Employee FindById(int id);
        IEnumerable<Employee> GetEmployees();
        void Dispose();

        IEnumerable<Employee> FindAllAvailableEmployees(List<TravelPlan> travelPlans);
        IEnumerable<Employee> FindByIds(List<int> ids);
    }
}
