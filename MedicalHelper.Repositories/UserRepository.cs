using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly MedicalHelperDbContext _dbContext;
        private readonly DbSet<User> _dbSet;

        public UserRepository(MedicalHelperDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<User>();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            return await _dbSet
                .SingleOrDefaultAsync(x => x.Login == login && x.Password == password);
        }               
    }
}
