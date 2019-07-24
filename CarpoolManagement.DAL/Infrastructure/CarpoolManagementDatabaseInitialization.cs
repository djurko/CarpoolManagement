using System;
using CarpoolManagement.Common.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace CarpoolManagement.DAL.Infrastructure
{
    public class CarpoolManagementDatabaseInitialization : DropCreateDatabaseAlways<CarpoolManagementContext>
    {
        protected override void Seed(CarpoolManagementContext context)
        {
            var carpools = new List<Carpool>
            {
                new Carpool{Id = 1, Name = "Ford for 1", CarType = "Ford Bronco", Color = "Blue", Plates = "ZG 123-AB", NumberOfSeats = 5},
                new Carpool{Id = 2, Name = "Infiniti for 2", CarType = "Infiniti G", Color = "Red", Plates = "RI 456-CD", NumberOfSeats = 4},
                new Carpool{Id = 3, Name = "Dodge for 3", CarType = "Dodge Stratus", Color = "Yellow", Plates = "VU 789-EF", NumberOfSeats = 5},
                new Carpool{Id = 4, Name = "Porsche for 4", CarType = "Porsche 911", Color = "Green", Plates = "DE 987-GH", NumberOfSeats = 4},
                new Carpool{Id = 5, Name = "Cadillac for 5", CarType = "Cadillac SRX", Color = "Purple", Plates = "ST 654-IJ", NumberOfSeats = 5},
                new Carpool{Id = 6, Name = "Bentley for 6", CarType = "Bentley Azure T", Color = "Pink", Plates = "VK 321-KL", NumberOfSeats = 4},
                new Carpool{Id = 7, Name = "Lincoln for 7", CarType = "Lincoln Navigator", Color = "Gray", Plates = "KR 111-MN", NumberOfSeats = 5},
                new Carpool{Id = 8, Name = "Toyota for 8", CarType = "Toyota Yaris", Color = "Black", Plates = "DA 222-OP", NumberOfSeats = 4},
                new Carpool{Id = 9, Name = "Mini for 9", CarType = "Mini Cooper", Color = "White", Plates = "GS 333-QR", NumberOfSeats = 5},
                new Carpool{Id = 10, Name = "Audi for 10", CarType = "Audi S6", Color = "Orange", Plates = "BJ 444-ST", NumberOfSeats = 4}
            };

            carpools.ForEach(c => context.Carpools.Add(c));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee{Id = 1, Name = "Laurie Goodwins", IsDriver = true},
                new Employee{Id = 2, Name = "Silas Embury", IsDriver = false},
                new Employee{Id = 3, Name = "Kathye Boxhall", IsDriver = true},
                new Employee{Id = 4, Name = "Hamlen Garment", IsDriver = false},
                new Employee{Id = 5, Name = "Jean Prozillo", IsDriver = true},
                new Employee{Id = 6, Name = "Iosep Fearneley", IsDriver = false},
                new Employee{Id = 7, Name = "Demetri Sorensen", IsDriver = true},
                new Employee{Id = 8, Name = "Tripp Edmondson", IsDriver = false},
                new Employee{Id = 9, Name = "Aron Hutchinges", IsDriver = true},
                new Employee{Id = 10, Name = "Bevin Laflin", IsDriver = false},
                new Employee{Id = 11, Name = "Aleksandr Tuckerman", IsDriver = true},
                new Employee{Id = 12, Name = "Kort Bohlmann", IsDriver = false},
                new Employee{Id = 13, Name = "Jennica Comoletti", IsDriver = true},
                new Employee{Id = 14, Name = "Kellina Wingeatt", IsDriver = false},
                new Employee{Id = 15, Name = "Elton Murphey", IsDriver = true},
                new Employee{Id = 16, Name = "Mimi Glas", IsDriver = false},
                new Employee{Id = 17, Name = "Lea Banton", IsDriver = true},
                new Employee{Id = 18, Name = "Tate Gosney", IsDriver = false},
                new Employee{Id = 19, Name = "June Brearty", IsDriver = true},
                new Employee{Id = 20, Name = "Mendy Wadforth", IsDriver = false},
                new Employee{Id = 21, Name = "Woodman Vivien", IsDriver = true},
                new Employee{Id = 22, Name = "Nixie Goom", IsDriver = false},
                new Employee{Id = 23, Name = "Larisa Liddington", IsDriver = true},
                new Employee{Id = 24, Name = "Tina Maunton", IsDriver = false},
                new Employee{Id = 25, Name = "Candace Crone", IsDriver = true},
            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            var travelPlans = new List<TravelPlan>
            {
                new TravelPlan{Id = 1, StartLocation = "Zagreb", EndLocation = "Malinska", StartDate = new DateTime(2019, 7, 20, 12, 0, 0), EndDate = new DateTime(2019, 7, 20, 14, 0, 0), CarId = 1},
                new TravelPlan{Id = 2, StartLocation = "Zagreb", EndLocation = "Split", StartDate = new DateTime(2019, 7, 20, 13, 0, 0), EndDate = new DateTime(2019, 7, 20, 15, 0, 0), CarId = 2}
            };

            travelPlans.ForEach(t => context.TravelPlans.Add(t));
            context.SaveChanges();

            var employeeTravelPlans = new List<EmployeeTravelPlan>
            {
                new EmployeeTravelPlan{Id = 1, TravelPlanId = 1, EmployeeId = 1},
                new EmployeeTravelPlan{Id = 2, TravelPlanId = 1, EmployeeId = 2},
                new EmployeeTravelPlan{Id = 3, TravelPlanId = 2, EmployeeId = 3},
                new EmployeeTravelPlan{Id = 3, TravelPlanId = 2, EmployeeId = 4}
            };

            employeeTravelPlans.ForEach(et => context.EmployeeTravelPlans.Add(et));
            context.SaveChanges();
        }
    }
}
