using MedicalHelper.EfStaff.Repositories;
using MedicalHelper.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class UserController : Controller
    {
        public UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            int id = 2;
            var user = _userRepository.Get(id);

            var viewModel = new UserViewModel();
                        
            viewModel.Id = user.Id;
            viewModel.Login = user.Login;
            viewModel.PasswordHash = user.PasswordHash;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            var allUsers = _userRepository.GetAll();

            //var viewModels = _mapper.Map<List<UserViewModel>>(allUsers);
                       
            List <UserViewModel> viewModels = new List<UserViewModel>();
           
            foreach (var user in allUsers)
            {
                var viewModel = new UserViewModel();

                viewModel.Id = user.Id;
                viewModel.Login = user.Login;
                viewModel.PasswordHash = user.PasswordHash;

                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }
    }
}
