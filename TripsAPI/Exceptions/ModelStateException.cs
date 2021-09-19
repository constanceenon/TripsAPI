using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsAPI.Exceptions
{
    /// <summary>
    /// Handles Exception
    /// </summary>
    public class ModelStateException : Exception
    {
        private ModelStateDictionary _ModelState;
        public ModelStateException()
        {

        }

        public ModelStateException(ModelStateDictionary ModelState)
        {
            _ModelState = ModelState;
        }
    }
}
