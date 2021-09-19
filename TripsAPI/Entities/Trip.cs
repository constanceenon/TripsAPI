using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.TripsEnum;

namespace TripsAPI.Entities
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public string Discription { get; set; }
        public TripEnum TripEnum { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public TripUser TripUser { get; set; }
        public DateTime DateCreated { get; set; }
             
    }
}
