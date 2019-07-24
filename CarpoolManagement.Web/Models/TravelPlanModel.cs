using CarpoolManagement.Common.Models;
using System;
using System.Collections.Generic;

namespace CarpoolManagement.Web.Models
{
    public class TravelPlanModel
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        //public Carpool Car { get; set; }
        public List<int> EmployeeIds { get; set; }
        public bool HasDriver { get; set; }

        public void MapTo(TravelPlan travelPlan)
        {
            Id = travelPlan.Id;
            StartLocation = travelPlan.StartLocation;
            EndLocation = travelPlan.EndLocation;
            StartDate = travelPlan.StartDate;
            EndDate = travelPlan.EndDate;
            CarId = travelPlan.CarId;
        }
    }
}