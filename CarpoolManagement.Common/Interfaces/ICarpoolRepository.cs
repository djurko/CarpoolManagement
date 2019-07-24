using System.CodeDom.Compiler;
using CarpoolManagement.Common.Models;
using System.Collections.Generic;

namespace CarpoolManagement.Common.Interfaces
{
    public interface ICarpoolRepository
    {
        void Add(Carpool carpool);
        void Edit(Carpool carpool);
        void Remove(int id);
        Carpool FindById(int id);
        IEnumerable<Carpool> GetCarpools();
        void Dispose();

        bool IsUniquePlates(string plates, int id);
        IEnumerable<Carpool> FindAllAvailableCarpools(List<TravelPlan> travelPlans);
    }
}
