using AutoMapper;
using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class VaccinationController : Controller
    {
        private readonly VaccinationService _vaccinationService;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public VaccinationController(VaccinationService vaccinationService,
            UserService userService, IMapper mapper)
        {
            _vaccinationService = vaccinationService;
            _userService = userService;
            _mapper = mapper;
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
