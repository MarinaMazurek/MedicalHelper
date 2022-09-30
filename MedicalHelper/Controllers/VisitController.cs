using MedicalHelper.Business.ServicesImplementations;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Models;
using MedicalHelper.Models.Visit;
using MedicalHelper.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class VisitController : Controller
    {
        private readonly VisitRepository _visitRepository;
        private readonly UserService _userService;

        public VisitController(VisitRepository visitRepository, UserService userService)
        {
            _visitRepository = visitRepository;
            _userService = userService;
        }


        //add some Visit

        [HttpGet]
        public IActionResult VisitAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VisitAdd(VisitAddViewModel viewModel)
        {
            var user = _userService.GetCurrentUserAsync();

            var visit = new Visit();

            visit.UserId = user.Id;
            visit.SpecializationOfDoctor = viewModel.SpecializationOfDoctor;
            visit.FullNameOfDoctor = viewModel.FullNameOfDoctor;
            visit.DateTime = viewModel.DateTime;

            _visitRepository.Add(visit);

            return RedirectToAction("GetAllVisits");
        }




        [HttpGet]
        public IActionResult GetVisit()
        {
            Guid id = Guid.NewGuid();

            var visit = _visitRepository.GetVisit(id);

            var viewModel = new VisitViewModel();

            viewModel.SpecializationOfDoctor = visit.SpecializationOfDoctor;
            viewModel.FullNameOfDoctor = visit.FullNameOfDoctor;
            viewModel.DateTime = visit.DateTime;
            //viewModel.User = visit.User;

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult GetAllVisits()
        {
            var allVisits = _visitRepository.GetAllVisits();

            List<VisitViewModel> viewModels = new List<VisitViewModel>();

            foreach (var visit in allVisits)
            {
                var viewModel = new VisitViewModel();

                viewModel.SpecializationOfDoctor = visit.SpecializationOfDoctor;
                viewModel.FullNameOfDoctor = visit.FullNameOfDoctor;
                viewModel.DateTime = visit.DateTime;
                //viewModel.User = visit.User;
                //viewModel.DataOfBirth = visit.DataOfBirth.ToString("D");                

                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }




    }
}
