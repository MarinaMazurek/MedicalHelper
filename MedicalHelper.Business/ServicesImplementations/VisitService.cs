using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions;
using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Business.ServicesImplementations
{
    public class VisitService : IVisitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VisitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(VisitDto visitDto)
        {
            var entity = _mapper.Map<Visit>(visitDto);
            await _unitOfWork.Visits.AddAsync(entity);
        }

        public async Task DeleteVisitByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Visits.GetEntityByIdAsync(id);
            _unitOfWork.Visits.Remove(entity);
        }

        public async Task<VisitDto> GetVisitByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Visits.GetEntityByIdAsync(id);
            var visitDto = _mapper.Map<VisitDto>(entity);
            return visitDto;
        }

        public async Task<List<VisitDto>> GetAllVisitsAsync(Guid userId)
        {
            var entities = await _unitOfWork.Visits.GetAllVisitsByUserIdAsync(userId);
            var visitsDto = _mapper.Map<List<VisitDto>>(entities);
            return visitsDto;
        }
    }
}
