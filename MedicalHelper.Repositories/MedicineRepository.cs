using MedicalHelper.Data.Abstractions.Repositories;
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
    public class MedicineRepository: Repository<Medicine>, IMedicineRepository
    {
        public readonly DbSet<Medicine> _dbSet;

        public MedicineRepository(MedicalHelperDbContext dbContext) : base(dbContext)
        {            
            _dbSet = dbContext.Set<Medicine>();
        }

        public async Task<List<Medicine>> GetAllMedicinesByVisitIdAsync(Guid id)
        {
            return await _dbSet
                .Where(x => x.VisitId == id)
                .ToListAsync();
        }

        
    }
}
