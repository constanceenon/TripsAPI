using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.Entities;
using TripsAPI.TripsEnum;

namespace TripsAPI.InputModels
{
    public class TripInputModel
    {
        public string Location { get; set; }
        public string Discription { get; set; }
        public TripEnum TripEnum { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public TripUser TripUser { get; set; }
    }
}
