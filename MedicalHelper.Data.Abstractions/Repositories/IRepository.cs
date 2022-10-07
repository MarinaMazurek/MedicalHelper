using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Data.Abstractions.Repositories
{
    public interface IRepository<T> where T : IBaseEntity
    {
        //READ        
        IQueryable<T> Get();
        Task<T?> GetEntityByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> FindBy(Expression<Func<T, bool>> searchExpression,
            params Expression<Func<T, object>>[] includes);

        //CREATE
        Task AddAsync(T entity);
        //Task AddRangeAsync(IEnumerable<T> entities);

        //UPDATE
        void Update(T entity);
        //Task PatchAsync(Guid id, List<PatchModel> patchData);


        //DELETE
        void Remove(T entity);           
    }
}
