using AutoMapper;
using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MedicalHelper.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IUserService _userService;
        private readonly IVisitService _visitService;
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;
        public MedicineController(IUserService userService, IVisitService visitService, 
            IMedicineService medicineService, IMapper mapper)
        {
            _userService = userService;
            _visitService = visitService;
            _medicineService = medicineService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MedicineAdd()
        {
            var currentUser = await _userService.GetCurrentUserAsync();
            
            var allVisitsDto = await _visitService.GetAllVisitsAsync(currentUser.Id);

            ViewBag.Visits = new SelectList(allVisitsDto, "Id", "Name");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MedicineAdd(MedicineViewModel viewModel)
        {
            var medicineDto = _mapper.Map<MedicineDto>(viewModel);
            await _medicineService.AddAsync(medicineDto);

            return RedirectToAction("GetAllMedicine");
        }

        [HttpGet]
        public async Task<IActionResult> MedicineDelete(Guid id)
        {
            await _medicineService.DeleteMedicineByIdAsync(id);

            return RedirectToAction("GetAllMedicine");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicine()
        {
            var allMedicinesDto = await _medicineService.GetAllMedicinesAsync();
            var medicineViewModels = _mapper.Map<List<MedicineViewModel>>(allMedicinesDto);

            foreach (var medicineViewModel in medicineViewModels)
            {
                var visit = await _visitService.GetVisitByIdAsync(medicineViewModel.VisitId);
                medicineViewModel.SpecializationOfDoctor = visit.Specialization.ToString();
                medicineViewModel.VisitDateTime = visit.DateTime;
            }

            return View(medicineViewModels);
        }
    }
}
