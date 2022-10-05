﻿using AutoMapper;
using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var userDtoReturn = await _userService
                .GetUserByEmailAndPasswordAsync(viewModel.Email, viewModel.Password);

            if (userDtoReturn == null)
            {
                var userDto = _mapper.Map<UserDto>(viewModel);
                await _userService.AddAsync(userDto);

                // делаем запрос, чтобы получить id - нужно для claim
                var userDtoForId = await _userService
                    .GetUserByEmailAndPasswordAsync(viewModel.Email, viewModel.Password);

                await HttpContext.SignInAsync(_userService.GetPrincipal(userDtoForId));

                return RedirectToAction("UserProfileAdd", "UserProfile");
            }
            else
            {
                ModelState.AddModelError(nameof(RegistrationViewModel.Email),
                    "Пользователь с указанным логином уже существует");
                return View(viewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckEmail(string email)
        {
            try
            {
                var isExist = await _userService.IsEmailExistAsync(email);
                
                if (isExist)
                {
                    return Ok(false);
                }
                return Ok(true);
            }
            catch(Exception e)
            {
                //Log.Error(e, e.Message);
                return StatusCode(500);
            }           
        }





        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new RegistrationViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegistrationViewModel viewModel)
        {

            var userDtoReturn = await _userService
                .GetUserByEmailAndPasswordAsync(viewModel.Email, viewModel.Password);

            if (userDtoReturn == null)
            {
                ModelState.AddModelError(nameof(RegistrationViewModel.Email),
                    "Wrong email or password");
                return View(viewModel);
            }

            await HttpContext.SignInAsync(_userService.GetPrincipal(userDtoReturn));

            // TO DO
            return RedirectToAction("MyProfile", "UserProfile");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);

            var viewModel = _mapper.Map<UserViewModel>(userDto);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsersDto = await _userService.GetAllUsersAsync();

            var viewModels = _mapper.Map<List<UserViewModel>>(allUsersDto);

            return View(viewModels);
        }
    }
}
