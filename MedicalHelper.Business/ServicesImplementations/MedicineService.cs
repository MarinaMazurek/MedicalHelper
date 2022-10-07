using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions;

namespace MedicalHelper.Business.ServicesImplementations
{

    public class MedicineService : IMedicineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MedicineDto>> GetAllMedicinesAsync(Guid id)
        {
            var allMedicines = await _unitOfWork.Medicines.GetAllMedicinesByVisitIdAsync(id);

            List<MedicineDto> list = _mapper.Map<List<MedicineDto>>(allMedicines);

            return list;
        }

    }
}
