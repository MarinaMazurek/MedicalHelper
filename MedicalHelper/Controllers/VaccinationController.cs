using AutoMapper;
using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Models;
using MedicalHelper.Models.Visit;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class VaccinationController : Controller
    {
        private readonly IVaccinationService _vaccinationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public VaccinationController(IVaccinationService vaccinationService,
            IUserService userService, IMapper mapper)
        {
            _vaccinationService = vaccinationService;
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> VaccinationAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VaccinationAdd(VaccinationViewModel viewModel)
        {
            var userDto = await _userService.GetCurrentUserAsync();

            var vaccinationDto = _mapper.Map<VaccinationDto>(viewModel);
            vaccinationDto.UserId = userDto.Id;

            await _vaccinationService.AddAsync(vaccinationDto);

            return RedirectToAction("GetAllUserVaccinations");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUserVaccinations()
        {
            var userDto = await _userService.GetCurrentUserAsync();

            var allVaccinationsDto = await _vaccinationService
                .GetAllVaccinationsAsync(userDto.Id);

            var viewModels = _mapper.Map<List<VaccinationViewModel>>(allVaccinationsDto);

            return View(viewModels);
        }
    }
}
