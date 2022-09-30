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
    public class VisitRepository
    {
        public MedicalHelperDbContext _dbContext;
        public DbSet<Visit> _dbSet;

        public VisitRepository(MedicalHelperDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Visit>();
        }

        public Visit GetVisit(Guid visitId)
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
