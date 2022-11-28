using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.WebAPI.Models;
using MedicalHelper.WebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;

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
            
            var allVisitsDto = await _visitService.GetAllVisitsAsync(new Guid("77029fd9-9550-47f5-d837-08daa89f2be5"));
            
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
