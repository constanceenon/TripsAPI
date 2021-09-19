using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsAPI.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Discription { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public TripUser TripUser { get; set; }
    }
}
