using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Repositories
{
    public class VisitRepository
    {
        public MedicalHelperDbContext _dbContext;
        public DbSet<Visit> _dbSet;

        public VisitRepository(MedicalHelperDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Visit>();
        }

        public async Task AddAsync(Visit visit)
        {
            await _dbSet.AddAsync(visit);
            _dbContext.SaveChanges();
        }

        public async Task<List<Visit>> GetAllVisitsByUserIdAsync(Guid id)
        {
            return await _dbSet
                .Where(x => x.UserId == id)
                .ToListAsync();
        }
    }
}
