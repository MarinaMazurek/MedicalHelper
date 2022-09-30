
using AutoMapper;
using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class MedicineController : Controller
    {
        private readonly MedicineService _medicineService;
        private readonly IMapper _mapper;
        public MedicineController(MedicineService medicineService,IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMedicine()
        {
            Guid id = Guid.NewGuid();
            var medicineDto = _medicineService.GetMedicine(id);

            var viewModel = _mapper.Map<MedicineViewModel>(medicineDto);                       

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetAllMedicine()
        {
            var allMedicines = _medicineService.GetAllMedicine();         

            List<MedicineViewModel> viewModels = _mapper.Map<List<MedicineViewModel>>(allMedicines);

            return View(viewModels);
        }
    }
}
