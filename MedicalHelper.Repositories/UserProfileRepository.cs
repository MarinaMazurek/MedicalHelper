using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Repositories
{
    public class UserProfileRepository
    {
        public MedicalHelperDbContext _dbContext;
        public DbSet<UserProfile> _dbSet;

        public UserProfileRepository(MedicalHelperDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<UserProfile>();
        }

        public async Task<UserProfile?> GetUserProfileByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserProfile>> GetAllUserProfilesAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task SaveAsync(UserProfile userProfile)
        {
            await _dbSet.AddAsync(userProfile);
            _dbContext.SaveChanges();
        }
    }
}
