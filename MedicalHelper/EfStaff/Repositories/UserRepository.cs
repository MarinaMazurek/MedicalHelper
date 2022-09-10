using MedicalHelper.EfStaff.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.EfStaff.Repositories
{
    public class UserRepository
    {
        public MedicalHelperDbContext _dbContext;
       
        public DbSet<User> _dbSet;
       
        public UserRepository(MedicalHelperDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<User>();
        }

        public User Get(int id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return _dbSet.ToList();
        }

    }
}
