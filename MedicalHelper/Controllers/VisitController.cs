using MedicalHelper.EfStaff.Model;
using MedicalHelper.EfStaff.Repositories;
using MedicalHelper.Models;
using MedicalHelper.Models.Visit;
using Microsoft.AspNetCore.Mvc;

namespace MedicalHelper.Controllers
{
    public class VisitController : Controller
    {
        public VisitRepository _visitRepository;

        public VisitController(VisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
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
            var visit = new Visit();

            visit.UserId = 10;
            visit.SpecializationOfDoctor = viewModel.SpecializationOfDoctor;
            visit.FullNameOfDoctor = viewModel.FullNameOfDoctor;
            visit.DateTime = viewModel.DateTime;

            _visitRepository.Add(visit);

            return RedirectToAction("GetAllVisits");
        }




        [HttpGet]
        public IActionResult GetVisit()
        {
            int id = 4;
            var visit = _visitRepository.GetVisit(id);

            var viewModel = new VisitViewModel();

            viewModel.SpecializationOfDoctor = visit.SpecializationOfDoctor;
            viewModel.FullNameOfDoctor = visit.FullNameOfDoctor;
            viewModel.DateTime = visit.DateTime;
            viewModel.User = visit.User;

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
                viewModel.User = visit.User;
                //viewModel.DataOfBirth = visit.DataOfBirth.ToString("D");                

                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }




    }
}
