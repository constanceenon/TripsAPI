
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsAPI.Exceptions
{
    /// <summary>
    /// Handles Exception
    /// </summary>
    public class UnauthorizedException : Exception
    {
        public string[] Permissions { get; set; } = (new List<string>()).ToArray();
        public UnauthorizedException()
        {

        }
        public UnauthorizedException(string message) : base(message)
        {

        }

        public UnauthorizedException(string message, string[] permissions) : base(message)
        {
            Permissions = permissions;
        }
    }
}
