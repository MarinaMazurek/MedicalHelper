using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Repositories
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        public DbSet<Visit> _dbSet;

        public VisitRepository(MedicalHelperDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Visit>();
        }

        public async Task<List<Visit>> GetAllVisitsByUserIdAsync(Guid id)
        {
            return await _dbSet
                .Where(x => x.UserId == id)
                .ToListAsync();
        }
    }
}
