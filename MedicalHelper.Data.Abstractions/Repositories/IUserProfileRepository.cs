using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Data.Abstractions.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        Task<UserProfile?> GetUserProfileByUserIdAsync(Guid userId);
    }
}
