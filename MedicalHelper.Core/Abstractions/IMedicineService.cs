using MedicalHelper.Core.DataTransferObjects;

namespace MedicalHelper.Core.Abstractions
{
    public interface IMedicineService
    {
        public Task AddAsync(MedicineDto medicineDto);
        public Task DeleteMedicineByIdAsync(Guid id);
        Task<List<MedicineDto>> GetAllMedicinesAsync();
    }
}
