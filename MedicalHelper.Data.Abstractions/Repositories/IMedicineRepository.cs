using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Data.Abstractions.Repositories
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAllMedicinesByVisitIdAsync(Guid id);
    }
}
