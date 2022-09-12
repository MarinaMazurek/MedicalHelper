using MedicalHelper.EfStaff.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.EfStaff.Repositories
{
    public class VaccinationRepository
    {
        public MedicalHelperDbContext _dbContext;

        public DbSet<Vaccination> _dbSet;

        public VaccinationRepository(MedicalHelperDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Vaccination>();
        }

        public Vaccination GetVaccination(int id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<Vaccination> GetAllVaccination()
        {
            return _dbSet.ToList();
        }
    }
}
