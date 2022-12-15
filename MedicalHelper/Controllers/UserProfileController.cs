using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Models.UserProfile;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UserProfileController(IUserService userService,
            IUserProfileService userProfileService, IMapper mapper)
        {
            _userService = userService;
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult UserProfileAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserProfileAdd(UserProfileAddViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(viewModel);
            //    //сообщение
            //}

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
            var userProfileDto = await _userProfileService
                .GetUserProfileByUserIdAsync(userDto.Id);

            var userProfileViewModel = _mapper.Map<UserProfileViewModel>(userProfileDto);

            return View(userProfileViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            var allUserProfilesDto = await _userProfileService.GetAllUserProfilesAsync();

            var viewModels = _mapper.Map<List<UserProfileViewModel>>(allUserProfilesDto);

            return View(viewModels);
        }
    }
}
