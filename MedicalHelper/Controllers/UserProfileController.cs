using MedicalHelper.EfStaff.Model;
using MedicalHelper.EfStaff.Repositories;
using MedicalHelper.Models;
using MedicalHelper.Models.UserProfile;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class UserProfileController : Controller
    {
        public UserProfileRepository _userProfileRepository;

        public UserProfileController(UserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }


        //add some UserProfile

        [HttpGet]
        public IActionResult UserProfileAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserProfileAdd(UserProfileAddViewModel viewModel)
        {  
            var userProfile = new UserProfile();

            userProfile.UserId = 10;
            userProfile.FirstName = viewModel.FirstName;
            userProfile.LastName = viewModel.LastName;
            userProfile.DataOfBirth = viewModel.DataOfBirth;
            userProfile.AvatarUrl = viewModel.AvatarUrl;
            userProfile.Address = viewModel.Address;
            userProfile.FullName = viewModel.FirstName + " " + viewModel.LastName;
           
            _userProfileRepository.Add(userProfile);

            return RedirectToAction("GetAllUserProfile");            
        }



        [HttpGet]
        public IActionResult GetUserProfile()
        {
            int id = 4;
            var userProfile = _userProfileRepository.GetUserProfileById(id);

            var viewModel = new UserProfileViewModel();

            viewModel.FullName = userProfile.FullName;
            viewModel.FirstName = userProfile.FirstName;
            viewModel.LastName = userProfile.LastName;
            viewModel.DataOfBirth = userProfile.DataOfBirth.ToString("D");
            viewModel.AvatarUrl = userProfile.AvatarUrl;
            viewModel.Address = userProfile.Address;                        

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult GetAllUserProfile()
        {
            var allUserProfiles = _userProfileRepository.GetAllUserProfiles();
                       
            List<UserProfileViewModel> viewModels = new List<UserProfileViewModel>();

            foreach (var userProfile in allUserProfiles)
            {
                var viewModel = new UserProfileViewModel();

                viewModel.Id = userProfile.Id;                
                viewModel.FullName = userProfile.FullName;
                viewModel.FirstName = userProfile.FirstName;
                viewModel.LastName = userProfile.LastName;
                viewModel.DataOfBirth = userProfile.DataOfBirth.ToString("D");
                viewModel.AvatarUrl = userProfile.AvatarUrl;
                viewModel.Address = userProfile.Address;

                viewModels.Add(viewModel);
            }
            return View(viewModels);
        }




    }
}
