using System.Collections.Generic;
using CarpoolManagement.Common.Models;

namespace CarpoolManagement.Web.Models
{
    public class CarpoolModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
        public string Color { get; set; }
        public string Plates { get; set; }
        public int NumberOfSeats { get; set; }

        public void MapTo(Carpool carpool)
        {
            Id = carpool.Id;
            Name = carpool.Name;
            CarType = carpool.CarType;
            Color = carpool.Color;
            Plates = carpool.Plates;
            NumberOfSeats = carpool.NumberOfSeats;
        }

        public static List<CarpoolModel> MapToList(List<Carpool> carpools)
        {
            List<CarpoolModel> result = new List<CarpoolModel>();
            foreach (var el in carpools)
            {
                CarpoolModel car = new CarpoolModel();
                car.MapTo(el);
                result.Add(car);
            }

            return result;
        }
    }
}