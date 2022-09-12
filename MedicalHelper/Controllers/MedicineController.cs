using MedicalHelper.EfStaff.Model;
using MedicalHelper.EfStaff.Repositories;
using MedicalHelper.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class MedicineController : Controller
    {
        public MedicineRepository _medicineRepository;

        public MedicineController(MedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [HttpGet]
        public IActionResult GetMedicine()
        {
            int id = 2;
            var medicine = _medicineRepository.GetMedicine(id);

            var viewModel = new MedicineViewModel();

            viewModel.Name = medicine.Name;
            viewModel.Cost = medicine.Cost;
            viewModel.FullCost = medicine.FullCost;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetAllMedicine()
        {
            var allMedicines = _medicineRepository.GetAllMedicine();

            //var viewModels = _mapper.Map<List<UserViewModel>>(allUsers);

            List<MedicineViewModel> viewModels = new List<MedicineViewModel>();

            foreach (var medicine in allMedicines)
            {
                var viewModel = new MedicineViewModel();

                viewModel.Name = medicine.Name;
                viewModel.Cost = medicine.Cost;
                viewModel.FullCost = medicine.FullCost;

                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }
    }
}
