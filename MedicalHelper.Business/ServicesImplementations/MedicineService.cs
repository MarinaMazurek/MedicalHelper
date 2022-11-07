using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions;
using MedicalHelper.DataBase.Entities;

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

        public async Task AddAsync(MedicineDto medicineDto)
        {
            var entity = _mapper.Map<Medicine>(medicineDto);
            await _unitOfWork.Medicines.AddAsync(entity);
        }

        public async Task DeleteMedicineByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Medicines.GetEntityByIdAsync(id);
            _unitOfWork.Medicines.Remove(entity);
        }

        public async Task<List<MedicineDto>> GetAllMedicinesAsync()
        {
            var allMedicines = await _unitOfWork.Medicines.GetAllAsync();

            return _mapper.Map<List<MedicineDto>>(allMedicines);
        }
    }
}
