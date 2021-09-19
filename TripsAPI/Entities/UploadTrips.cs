using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.TripsEnum;

namespace TripsAPI.Entities
{
    public class UploadTrips
    {

        public int TripUserId { get; set; }
        public string Location { get; set; }
        public string Discription { get; set; }
        public TripEnum TripEnum { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string DateCreated { get; set; }
    }
}
