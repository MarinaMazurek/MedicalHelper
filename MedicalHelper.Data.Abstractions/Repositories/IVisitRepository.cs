using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Data.Abstractions.Repositories
{
    public interface IVisitRepository : IRepository<Visit>
    {
        Task<List<Visit>> GetAllVisitsByUserIdAsync(Guid id);
    }
}
