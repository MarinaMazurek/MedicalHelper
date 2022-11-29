using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.WebAPI.Models;
using MedicalHelper.WebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalHelper.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IVisitService _visitService;
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public VisitController(IUserService userService, IVisitService visitService, IMapper mapper, IMedicineService medicineService)
        {
            _userService = userService;
            _visitService = visitService;
            _medicineService = medicineService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get visit from storage with specified id
        /// </summary>
        /// <param name="id">Id of visit</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VisitModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVisitById(Guid id)
        {
            var visitDto = await _visitService.GetVisitByIdAsync(id);

            if (visitDto == null)
            {
                return NotFound();
            }

            var visit = _mapper.Map<VisitModel>(visitDto);
            return Ok(visit);
        }

        /// <summary>
        /// Get user visits
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(typeof(List<VisitModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllVisits()
        {
            //TODO: var userDto = await _userService.GetCurrentUserAsync();
            
            var allVisitsDto = await _visitService.GetAllVisitsAsync(new Guid("87f738b6-acae-4839-0182-08dad2432688"));
            
            if (allVisitsDto == null || !allVisitsDto.Any())
            {
                return NotFound();
            }

            var viewModels = _mapper.Map<List<VisitModel>>(allVisitsDto);
            return Ok(viewModels);
        }

        /// <summary>
        /// Delete Visit
        /// </summary>
        /// <param name="id">Id of visit</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VisitDelete(Guid id)
        {
            try
            {
                await _visitService.DeleteVisitByIdAsync(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorModel { Message = ex.Message });
            }
        }

        /// <summary>
        /// Update Visit
        /// </summary>
        /// <param name="id">Id of visit</param>
        /// <param name="visitModel">Model of visit for update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVisit(Guid id, [FromBody] UpdateVisitModel? visitModel)
        {
            if (visitModel == null)
            {
                return BadRequest();
            }

            var oldVisit = await _visitService.GetVisitByIdAsync(id);
            
            if (oldVisit == null)
            {
                return NotFound();
            }

            var newVisit = new VisitDto()
            {
                Id = oldVisit.Id,
                Name = visitModel.Name,
                Specialization = visitModel.Specialization,
                FullNameOfDoctor = visitModel.FullNameOfDoctor,
                DateTime = visitModel.DateTime,
                UserId = new Guid("87f738b6-acae-4839-0182-08dad2432688")
            };

            await _visitService.DeleteVisitByIdAsync(id);
            await _visitService.AddAsync(newVisit);

            return Ok();
        }

        /// <summary>
        /// Update name of doctor in visit
        /// </summary>
        /// <param name="id">Id of visit</param>
        /// <param name="visitModel">Model of visit for update</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVisit(Guid id, [FromBody] PatchVisitModel? visitModel)
        {
            if (visitModel == null)
            {
                return BadRequest();
            }

            var oldVisit = await _visitService.GetVisitByIdAsync(id);

            if (oldVisit == null)
            {
                return NotFound();
            }

            var newVisit = new VisitDto()
            {
                Id = oldVisit.Id,
                Name = oldVisit.Name,
                Specialization = oldVisit.Specialization,
                SpecializationOfDoctor = oldVisit.SpecializationOfDoctor,
                FullNameOfDoctor = visitModel.FullNameOfDoctor,
                DateTime = oldVisit.DateTime,
                Medicines = oldVisit.Medicines,
                UserId = new Guid("87f738b6-acae-4839-0182-08dad2432688")
            };

            await _visitService.DeleteVisitByIdAsync(id);
            await _visitService.AddAsync(newVisit);

            return Ok();
        }






        [HttpPost]
        public async Task<IActionResult> VisitAdd(VisitModel visitModel)
        {
            var userDto = await _userService.GetCurrentUserAsync();

            var visitDto = _mapper.Map<VisitDto>(visitModel);
            visitDto.UserId = userDto.Id;

            await _visitService.AddAsync(visitDto);

            return RedirectToAction("GetAllVisits");
        }
    }
}
