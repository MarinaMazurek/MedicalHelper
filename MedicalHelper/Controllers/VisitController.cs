using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Models.Visit;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class VisitController : Controller
    {
        private readonly IUserService _userService;
        private readonly IVisitService _visitService;
        private readonly IMapper _mapper;

        public VisitController(IUserService userService, IVisitService visitService, IMapper mapper, IMedicineService medicineService)
        {
            _userService = userService;
            _visitService = visitService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> VisitAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VisitAdd(VisitViewModel viewModel)
        {
            var userDto = await _userService.GetCurrentUserAsync();

            var visitDto = _mapper.Map<VisitDto>(viewModel);
            visitDto.UserId = userDto.Id;

            await _visitService.AddAsync(visitDto);

            return RedirectToAction("GetAllVisits");
        }

        [HttpGet]
        public async Task<IActionResult> VisitDelete(Guid id)
        {
            await _visitService.DeleteVisitByIdAsync(id);

            return RedirectToAction("GetAllVisits");
        }

        [HttpGet]
        public async Task<IActionResult> GetVisitById(Guid id)
        {
            var visitDto = await _visitService.GetVisitByIdAsync(id);

            var viewModel = _mapper.Map<VisitViewModel>(visitDto);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisits()
        {
            var userDto = await _userService.GetCurrentUserAsync();

            var allVisitsDto = await _visitService.GetAllVisitsAsync(userDto.Id);

            var viewModels = _mapper.Map<List<VisitViewModel>>(allVisitsDto);

            return View(viewModels);
        }
    }
}
