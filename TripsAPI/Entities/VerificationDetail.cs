using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.TripsEnum;

namespace TripsAPI.Entities
{
    public class VerificationDetail
    {
        public string IdNumber { get; set; }
        public string UserId { get; set; }
        public string IdentityFile { get; set; }
        public  VerificationStatus? Status { get; set; }
    }
}
