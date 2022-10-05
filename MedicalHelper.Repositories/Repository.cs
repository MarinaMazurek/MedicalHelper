using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.Repositories
{
    public class Repository<T> where T : class, IBaseEntity
    {
        private readonly MedicalHelperDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(MedicalHelperDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual IQueryable<T> Get()
        {
            return _dbSet;
        }
        public virtual async Task<T?> GetEntityByIdAsync(Guid id)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }              

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
