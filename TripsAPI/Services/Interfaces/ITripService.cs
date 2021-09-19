using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.Entities;

namespace TripsAPI.Services.Interfaces
{
   public interface ITripService
    {
        Task<List<Trip>> GetUserTrip(int userId);
        Task<List<Trip>> AllTrips();
    }
}
