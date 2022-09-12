using MedicalHelper.EfStaff.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.EfStaff.Repositories
{
    public class MedicineRepository
    {
        public MedicalHelperDbContext _dbContext;

        public DbSet<Medicine> _dbSet;

        public MedicineRepository(MedicalHelperDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Medicine>();
        }

        public Medicine GetMedicine(int id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<Medicine> GetAllMedicine()
        {
            return _dbSet.ToList();
        }
    }
}
