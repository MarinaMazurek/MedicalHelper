using MedicalHelper.EfStaff.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.EfStaff.Repositories
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

        public Visit GetVisit(int visitId)
        {
            return _dbSet
                .Where(x => x.Id == visitId)
                .FirstOrDefault();
        }

        public void Add(Visit visit)
        {
            _dbSet.Add(visit);
            _dbContext.SaveChanges();
        }

        public List<Visit> GetAllVisits()
        {
            return _dbSet.ToList();
        }
    }
}
