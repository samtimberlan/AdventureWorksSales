using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksSales.Repository
{
    /// <summary>
    /// Retrieves information for a specified entity from DB
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class QueryRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public QueryRepository()
        {
            _dbContext = ConnectionFactory.DbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAllNoTrackingAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync<TEntity>();
        }
        
        public async Task<IEnumerable<TEntity>> GetAllTracking()
        {
            return await _dbSet.ToListAsync<TEntity>();
        }

        public async Task<TEntity> GetByDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> GetQueryableEntityNoTracking()
        {
            return _dbSet.AsNoTracking<TEntity>();
        }
    }
}
