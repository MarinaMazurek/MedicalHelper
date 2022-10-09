using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(MedicalHelperDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<User>();
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbSet
                .SingleOrDefaultAsync(x => x.Email == email && x.PasswordHash == passwordHash);
        }

        //public bool Exist(string email)
        //{
        //    return _dbSet.Any(x => x.Email == email);
        //}
    }
}
