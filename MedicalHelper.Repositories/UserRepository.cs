using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Repositories
{
    public class UserRepository
    {
        private readonly MedicalHelperDbContext _dbContext;
        private readonly DbSet<User> _dbSet;

        public UserRepository(MedicalHelperDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<User>();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User?> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            return await _dbSet
                .SingleOrDefaultAsync(x => x.Login == login && x.Password == password);
        }

        public async Task SaveAsync(User user)
        {
            await _dbSet.AddAsync(user);
            _dbContext.SaveChanges();
        }
    }
}
