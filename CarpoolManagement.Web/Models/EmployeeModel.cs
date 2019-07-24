using System.Collections.Generic;
using CarpoolManagement.Common.Models;

namespace CarpoolManagement.Web.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDriver { get; set; }

        public void MapTo(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            IsDriver = employee.IsDriver;
        }

        public static List<EmployeeModel> MapToList(List<Employee> employees)
        {
            List<EmployeeModel> result = new List<EmployeeModel>();
            foreach (var el in employees)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.MapTo(el);
                result.Add(emp);
            }

            return result;
        }
    }
}