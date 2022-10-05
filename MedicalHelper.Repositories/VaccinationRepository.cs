using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Repositories
{
    public class VaccinationRepository : Repository<Vaccination>, IVaccinationRepository
    {
        public readonly DbSet<Vaccination> _dbSet;

        public VaccinationRepository(MedicalHelperDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Vaccination>();
        }
        public async Task<List<Vaccination>> GetAllVaccinationsByUserIdAsync(Guid id)
        {
            return await _dbSet
                .Where(x => x.UserId == id)
                .ToListAsync();
        }
    }
}
