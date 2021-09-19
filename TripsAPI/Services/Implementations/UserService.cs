//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using TripsAPI.Entities;
//using TripsAPI.InputModels;
//using TripsAPI.Services.Interfaces;

//namespace TripsAPI.Services.Implementations
//{
//    public class UserService : IUserService
//    {
//        private readonly ILogger<UserService> _logger;
//        private readonly UserManager<TripUser> _userManager;
//        private readonly IAsyncRepository<VerificationDetail> _verificationRepository;
//        private readonly IAsyncRepository<UserProfile> _profileRepository;

//        public UserService(ILogger<UserService> logger,
//            UserManager<TripUser> userManager,
//            IAsyncRepository<VerificationDetail> verificationRepository,
//            IAsyncRepository<UserProfile> profileRepository)
//        {
//            _logger = logger;
//            _userManager = userManager;
//            _verificationRepository = verificationRepository;
//            _profileRepository = profileRepository;
//        }
//        public async Task CreateUserProfile()
//        {
//            await _profileRepository.AddAsync(new UserProfile());
//        }


//        public async Task<UserProfile> UpdateUserProfile(Guid Id, ClaimsPrincipal User, ProfileInputModel model)
//        {
//            var user = await _userManager.GetUserAsync(User);
//            if (user == null) throw new KeyNotFoundException("User not Found");

//            var profileDetail = await _profileRepository.GetByIdAsync(Id);
//            if (profileDetail == null) throw new KeyNotFoundException("Profile Detail not found");

//            profileDetail = new UserProfile
//            {
//                //ProfilePicture = model.ProfilePicture,
//                UserId = user.Id,
//                Bio = model.Bio,
//                Gender = model.Gender
//            };

//            await _profileRepository.UpdateAsync(profileDetail);
//            return profileDetail;
//        }

//        public async Task CreateVerificationDetails()
//        {
//            await _verificationRepository.AddAsync(new VerificationDetail());
//        }


//        public async Task<VerificationDetail> UpdateVerificationDetails(Guid Id, ClaimsPrincipal User, VerificationInputModel model)
//        {
//            var user = await _userManager.GetUserAsync(User);
//            if (user == null) throw new KeyNotFoundException("User not Found");

//            var verificationDetail = await _verificationRepository.GetByIdAsync(Id);
//            if (verificationDetail == null) throw new KeyNotFoundException("Verification Details not found");

//            verificationDetail = new VerificationDetail
//            {
//                IdNumber = model.IdNumber,
//                IdentityFile = model.IdentityFile,
//                UserId = user.Id,
//               // AddressVerificationFile = model.AddressVerificationFile,
//                Status = model.Status
//            };

//            await _verificationRepository.UpdateAsync(verificationDetail);
//            return verificationDetail;
//        }
//    }
//}