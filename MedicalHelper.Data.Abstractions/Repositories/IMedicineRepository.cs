using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Data.Abstractions.Repositories
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
        //Task<List<Medicine>> GetAllMedicinesByVisitIdAsync(Guid id);
    }
}
