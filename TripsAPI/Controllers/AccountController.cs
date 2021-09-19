using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TripsAPI.Entities;
using TripsAPI.Exceptions;
using TripsAPI.Helpers;
using TripsAPI.Services.Interfaces;
using TripsAPI.ViewModels;

namespace TripsAPI.Controllers
{
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<TripUser> _userManager;
        private readonly SignInManager<TripUser> _signInManager;
       // private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly ILogger<AccountController> _logger;
        private readonly ExceptionService _exceptionService;
        public AccountController(IAccountService accountService, UserManager<TripUser> userManager, SignInManager<TripUser> signInManager, IConfiguration config, ILogger<AccountController> logger, ExceptionService exceptionService)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
          //  _userService = userService;
            _config = config;
            _logger = logger;
            _exceptionService = exceptionService;
        }
        /// <summary>
        /// Endpoint to Register a User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterInputModel model)
        {
            try
            {
                var user = new TripUser { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, UserName=model.Email, GenderType = model.GenderType, };

               // var userNameExist = await _userManager.FindByNameAsync(model.FirstName);
              //  if (userNameExist != null) throw new KeyNotFoundException($"user with Username {userNameExist} already exist");

                var userEmailExist = await _userManager.FindByEmailAsync(model.Email);
                if (userEmailExist != null) throw new KeyNotFoundException($"user with Email {userEmailExist} already exist");

                var result = await _userManager.CreateAsync(user, model.Password);
                string passwordError = null;
                foreach (var error in result.Errors)
                {
                    passwordError = error.Description.ToString();
                }
                if (!result.Succeeded) throw new KeyNotFoundException(passwordError);

                _logger.LogInformation("User created a new account with password.");
                await _signInManager.SignInAsync(user, isPersistent: false);

                //await _userService.CreateUserProfile();
                //_logger.LogInformation("User Profile created Successfully.");

                //await _userService.CreateVerificationDetails();
                //_logger.LogInformation("User Verification Details created Successfully.");

                return Ok(new ResponseMessage
                {
                    Data = new
                    {
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        email = user.Email,
                    },
                    Status = true
                });
            }
            catch (Exception ex)
            {
                return _exceptionService.GetActionResult(ex);
            }
        }



        /// <summary>
        /// Endpoint to Login a user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginInputModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user == null) throw new KeyNotFoundException("Invalid Login Credentials");

                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (!result.Succeeded) throw new KeyNotFoundException("Invalid Password");

                var token = await _accountService.CreateToken(user);
                _logger.LogInformation($"Created token for {user.UserName}");

                return Ok(new ResponseMessage
                {
                    Data = new
                    {
                        accesstoken = token,
                        email = user.Email,
                        usename = user.UserName
                    },
                    Status = true
                });
            }
            catch (Exception ex)
            {
                return _exceptionService.GetActionResult(ex);
            }
        }

        /// <summary>
        /// Endpoint to logout the user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
