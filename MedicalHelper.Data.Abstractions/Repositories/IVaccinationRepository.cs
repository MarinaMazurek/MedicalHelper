using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Data.Abstractions.Repositories
{
    public interface IVaccinationRepository : IRepository<Vaccination>
    {
        Task<List<Vaccination>> GetAllVaccinationsByUserIdAsync(Guid id);
    }
}
