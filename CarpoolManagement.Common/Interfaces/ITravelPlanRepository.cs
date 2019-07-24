using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarpoolManagement.Common.Models;

namespace CarpoolManagement.Common.Interfaces
{
    public interface ITravelPlanRepository
    {
        void Add(TravelPlan travelPlan);
        void Edit(TravelPlan travelPlan);
        void Remove(int id);
        TravelPlan FindById(int id);
        IEnumerable<TravelPlan> GetTravelPlans();
        void Dispose();

        IEnumerable<TravelPlan> FindConflictingTravelPlans(DateTime startDate, DateTime endDate);
    }
}
