using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.Entities;
using TripsAPI.Services.Interfaces;

namespace TripsAPI.Services.Implementations
{
    public class TripService : ITripService
    {
        public Task<List<Trip>> AllTrips()
        {
            throw new NotImplementedException();
        }

        public Task<List<Trip>> GetUserTrip(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
