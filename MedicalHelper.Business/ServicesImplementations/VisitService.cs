using AutoMapper;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Business.ServicesImplementations
{
    public class VisitService
    {
        private readonly VisitRepository _visitRepository;
        private readonly IMapper _mapper;

        public VisitService(VisitRepository visitRepository, IMapper mapper)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(VisitDto visitDto)
        {
            var entity = _mapper.Map<Visit>(visitDto);
            await _visitRepository.AddAsync(entity);
        }

        public async Task<List<VisitDto>> GetAllVisitsAsync(Guid id)
        {
            var entities = await _visitRepository.GetAllVisitsByUserIdAsync(id);
            var visitsDto = _mapper.Map<List<VisitDto>>(entities);
            return visitsDto;
        }
    }
}
