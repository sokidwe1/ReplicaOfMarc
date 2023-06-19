using Data.Abstractions.IRepositories;
using Data.Implementations.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Base
    {
        protected GenericRepository(DbContextClass context)
        {
            _dbContext = context;
        }

        protected readonly DbContextClass _dbContext;

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
           
        }

        public async Task Update(T entity)
        {
            var existingEntity = await _dbContext.Set<T>().FindAsync(entity.Id);
            if(existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                entity.UpdatedOn = DateTime.UtcNow;
                _dbContext.Set<T>().Update(existingEntity);
            }
        }
    }
}
