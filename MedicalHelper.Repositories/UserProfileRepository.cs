using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public readonly DbSet<UserProfile> _dbSet;

        public UserProfileRepository(MedicalHelperDbContext dbContext): base(dbContext)
        {            
            _dbSet = dbContext.Set<UserProfile>();
        }

        public async Task<UserProfile?> GetUserProfileByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();
        }       
    }
}
