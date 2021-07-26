using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace notes.DataAccess.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly NotesContext _notesContext;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(NotesContext notesContext)
        {
            _notesContext = notesContext;
            _dbSet = notesContext.Set<TEntity>();
        }
        
        public async Task<TEntity> GetAsync(Func<TEntity, bool> predicate)
        {
            return await _dbSet.FindAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => _dbSet.AsNoTracking().AsEnumerable().Where(predicate).ToArray());
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _dbSet.AsNoTracking().ToArray());
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _notesContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _notesContext.Entry(entity).State = EntityState.Modified;
            await _notesContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _notesContext.SaveChangesAsync();
        }
    }
}