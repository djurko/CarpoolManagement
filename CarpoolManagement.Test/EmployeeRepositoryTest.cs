using CarpoolManagement.DAL.Infrastructure;
using CarpoolManagement.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CarpoolManagement.Common.Models;

namespace CarpoolManagement.Test
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        EmployeeRepository _repository;

        [TestInitialize]
        public void TestSetup()
        {
            CarpoolManagementDatabaseInitialization db = new CarpoolManagementDatabaseInitialization();
            System.Data.Entity.Database.SetInitializer(db);
            _repository = new EmployeeRepository(new CarpoolManagementContext());
        }

        [TestMethod]
        public void IsRepositoryInitalizedWithValidNumberOfData()
        {
            var result = _repository.GetEmployees();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(25, numberOfRecords);
        }

        [TestMethod]
        public void AddNewEmployeeTest()
        {
            Employee employeeToAdd = new Employee
            {
                Id = 26,
                Name = "Dominik Jurkovic",
                IsDriver = true
            };
            _repository.Add(employeeToAdd);
            var result = _repository.GetEmployees();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(26, numberOfRecords);
        }
    }
}
