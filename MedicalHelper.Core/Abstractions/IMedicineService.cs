using MedicalHelper.Core.DataTransferObjects;

namespace MedicalHelper.Core.Abstractions
{
    public interface IMedicineService
    {
        Task<List<MedicineDto>> GetAllMedicinesAsync(Guid id);
    }
}
