using AutoMapper;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Business.ServicesImplementations
{    
    public class VaccinationService
    {
        private readonly VaccinationRepository _vaccinationRepository;
        private readonly IMapper _mapper;

        public VaccinationService(VaccinationRepository vaccinationRepository, IMapper mapper)
        {
            _vaccinationRepository = vaccinationRepository;
            _mapper = mapper;
        }

        public async Task<List<VaccinationDto>> GetAllVaccinationsAsync(Guid id)
        {
            var entities = await _vaccinationRepository.GetAllVaccinationsByUserIdAsync(id);
            var vaccinationsDto = _mapper.Map<List<VaccinationDto>>(entities);
            return vaccinationsDto;
        }
    }
}
