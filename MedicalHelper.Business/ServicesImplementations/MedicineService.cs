using AutoMapper;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.Repositories;

namespace MedicalHelper.Business.ServicesImplementations
{

    public class MedicineService
    {
        private readonly IMapper _mapper;
        private readonly MedicineRepository _medicineRepository;

        public MedicineService(IMapper mapper, MedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }

        public async Task<List<MedicineDto>> GetAllMedicinesAsync(Guid id)
        {
            var allMedicines = await _medicineRepository.GetAllMedicinesByVisitIdAsync(id);

            List<MedicineDto> list = _mapper.Map<List<MedicineDto>>(allMedicines);

            return list;
        }

    }
}
