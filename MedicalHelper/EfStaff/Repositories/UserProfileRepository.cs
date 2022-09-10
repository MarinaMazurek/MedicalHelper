using MedicalHelper.EfStaff.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.EfStaff.Repositories
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

        public UserProfile GetUserProfileById(int userProfileId)
        {
            return _dbSet
                .Where(x => x.Id == userProfileId)
                .FirstOrDefault();
        }

        public void Add(UserProfile userProfile)
        {
            _dbSet.Add(userProfile);
            _dbContext.SaveChanges();
        }

        public List<UserProfile> GetAllUserProfiles()
        {
            return _dbSet.ToList();
        }

    }
}
