using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TripsAPI.Data.Repository;
using TripsAPI.Entities;
using TripsAPI.Exceptions;
using TripsAPI.Helpers;
using TripsAPI.InputModels;
using TripsAPI.Services.Interfaces;

namespace TripsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<TripUser> _userManager;
        private readonly SignInManager<TripUser> _signInManager;
        private readonly TripsRepository<Trip> _tripsRepository;
        // private readonly IAsyncRepository _efRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<AccountController> _logger;
        private readonly ExceptionService _exceptionService;
        public TripController(IAccountService accountService, IWebHostEnvironment environment, UserManager<TripUser> userManager, SignInManager<TripUser> signInManager, IConfiguration config, ILogger<AccountController> logger, ExceptionService exceptionService, TripsRepository<Trip> tripsRepository, IMapper mapper)//IAsyncRepository efRepository 
        {
            _accountService = accountService;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _tripsRepository = tripsRepository;
            // _efRepository = efRepository;
            _config = config;
            _logger = logger;
            _mapper = mapper;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// When a user wants to add a Trip
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
       // [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddTrip([FromBody]TripInputModel model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trip = _mapper.Map<Trip>(model);
            var addTrips = await _tripsRepository.InsertEntity(trip);
            return Ok(new ResponseMessage
            {
                Data = addTrips,
                Message = "Trips was added Successfully",
                ResponseCode = 200,
                Status = true
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult>UpdateTrip(int id,[FromQuery] TripInputModel inputModel)
        {
            if (id <= 0)
            {
                return NotFound(new ResponseMessage
                {
                    Data = null,
                    Message = "Invalid Id passed",
                    ResponseCode = 404,
                    Status = false
                    
                });
            }
           
            var getTrip = await _tripsRepository.GetEntity(id);
            if(getTrip == null)
            {
                return NotFound(new ResponseMessage
                {
                    Data = null,
                    Message = "Trip wasn;t found",
                    ResponseCode = 404,
                    Status = false
                });
            }
            var updateTrip = _tripsRepository.UpdateEntity(getTrip);
            return Ok(new ResponseMessage
            {
                Data = updateTrip,
                Message = "Trip updated Successfully",
                ResponseCode = 200,
                Status = true
            });
        }

        /// <summary>
        /// Delete a trip
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<ActionResult>DeleteTrip([FromQuery] int Id)
        {
            var getTrip = await _tripsRepository.GetEntity(Id);
            await _tripsRepository.DeleteEntity(getTrip);
            return Ok(new ResponseMessage
            {
                Data = null,
                Message = "Trip was successfully Deleted",
                ResponseCode = 200,
                Status = true
            });
        }

        /// <summary>
        /// Get a particular user Trip
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult>GetTripById([FromQuery] int id)
        {
            var getTrip = await _tripsRepository.GetEntity(id);
            return Ok(new ResponseMessage
            {
                Data = getTrip,
                Message = "Trip found",
                ResponseCode = 200,
                Status = true
            });
        }

        /// <summary>
        /// Get all Trips
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllTrips()
        {
            var allTrips = await _tripsRepository.GetEntities();
            return Ok(new ResponseMessage
            {
                Data = allTrips,
                Message = "Trips fetched Successfully",
                ResponseCode = 200,
                Status = true
            });
        }
    }
}