using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Business.ServicesImplementations
{
    public class VisitService: IVisitService
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

        public async Task<List<VisitDto>> GetAllVisitsAsync(Guid id)
        {
            var entities = await _unitOfWork.Visits.GetAllVisitsByUserIdAsync(id);
            var visitsDto = _mapper.Map<List<VisitDto>>(entities);
            return visitsDto;
        }
    }
}
