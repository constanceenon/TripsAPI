using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TripsAPI.Entities;

namespace TripsAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<List<Claim>> GetValidClaims(TripUser user);
        Task<string> CreateToken(TripUser user);
    }
}
