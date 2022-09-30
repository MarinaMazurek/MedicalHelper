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
    public class VaccinationRepository
    {
        public MedicalHelperDbContext _dbContext;

        public DbSet<Vaccination> _dbSet;

        public VaccinationRepository(MedicalHelperDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Vaccination>();
        }

        public Vaccination GetVaccination(Guid id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<Vaccination> GetAllVaccination()
        {
            return _dbSet.ToList();
        }
    }
}
