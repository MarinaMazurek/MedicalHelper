using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Repositories
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

        public Medicine GetMedicine(Guid id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<Medicine> GetAllMedicine()
        {
            return _dbSet.ToList();
        }
    }
}
