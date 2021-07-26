using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace notes.DataAccess.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}