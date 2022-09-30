using MedicalHelper.Models;
using MedicalHelper.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class VaccinationController : Controller
    {
        public VaccinationRepository _vaccinationRepository;

        public VaccinationController(VaccinationRepository vaccinationRepository)
        {
            _vaccinationRepository = vaccinationRepository;
        }

        [HttpGet]
        public IActionResult GetVaccination()
        {
            Guid id = Guid.NewGuid();

            var vaccination = _vaccinationRepository.GetVaccination(id);

            var viewModel = new VaccinationViewModel();

            viewModel.Name = vaccination.Name;
            viewModel.Date = vaccination.Date;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetAllVaccination()
        {
            var allVaccinations = _vaccinationRepository.GetAllVaccination();

            //var viewModels = _mapper.Map<List<UserViewModel>>(allUsers);

            List<VaccinationViewModel> viewModels = new List<VaccinationViewModel>();

            foreach (var vaccination in allVaccinations)
            {
                var viewModel = new VaccinationViewModel();

                viewModel.Name = vaccination.Name;
                viewModel.Date = vaccination.Date;

                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }
    }
}
