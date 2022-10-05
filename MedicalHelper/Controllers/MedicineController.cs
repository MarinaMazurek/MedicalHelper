
using AutoMapper;
using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class MedicineController : Controller
    {
        private readonly MedicineService _medicineService;
        private readonly IMapper _mapper;
        public MedicineController(MedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicine(Guid id)
        {
            var allMedicinesDto = await _medicineService.GetAllMedicinesAsync(id);

            List<MedicineViewModel> viewModels = _mapper.Map<List<MedicineViewModel>>(allMedicinesDto);

            return View(viewModels);
        }
    }
}
