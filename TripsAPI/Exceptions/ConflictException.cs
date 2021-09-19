using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsAPI.Exceptions
{
    public class ConflictException : Exception
    {
        /// <summary>
        /// Handles Exceptions
        /// </summary>
        /// <param name="message"></param>
        public ConflictException(string message) : base(message)
        {

        }
    }
}
