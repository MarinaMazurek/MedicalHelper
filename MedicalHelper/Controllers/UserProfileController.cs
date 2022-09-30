using AutoMapper;
using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Models.User;
using MedicalHelper.Models.UserProfile;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserService _userService;
        private readonly UserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UserProfileController(UserService userService, 
            UserProfileService userProfileService, IMapper mapper)
        {
            _userService = userService;
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult UserProfileAddAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserProfileAddAsync(UserProfileAddViewModel viewModel)
        {
            var userDto = await _userService.GetCurrentUserAsync();

            var userProfileDto = _mapper.Map<UserProfileDto>(viewModel);
            userProfileDto.UserId = userDto.Id;            

            await _userProfileService.AddAsync(userProfileDto);

            return RedirectToAction("MyProfile");
        }
                
        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            var userDto = await _userService.GetCurrentUserAsync();
            var userProfileDto = await _userProfileService.GetUserProfileByUserIdAsync(userDto.Id);

            var userProfileViewModel = _mapper.Map<UserProfileViewModel>(userProfileDto);         
                       
            return View(userProfileViewModel);
        }
                
        [HttpGet]
        public async Task<IActionResult> GetAllUserProfileAsync()
        {
            var allUserProfilesDto = await _userProfileService.GetAllUserProfilesAsync();

            var viewModels = _mapper.Map<List<UserProfileViewModel>>(allUserProfilesDto); 

            return View(viewModels);
        }
    }
}
