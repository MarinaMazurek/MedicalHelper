using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions;
using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Business.ServicesImplementations
{
    public class VaccinationService : IVaccinationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VaccinationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(VaccinationDto vaccinationDto)
        {
            var entity = _mapper.Map<Vaccination>(vaccinationDto);
            await _unitOfWork.Vaccinations.AddAsync(entity);
        }

        public async Task<List<VaccinationDto>> GetAllVaccinationsAsync(Guid id)
        {
            var entities = await _unitOfWork.Vaccinations.GetAllVaccinationsByUserIdAsync(id);
            var vaccinationsDto = _mapper.Map<List<VaccinationDto>>(entities);
            return vaccinationsDto;
        }
    }
}
