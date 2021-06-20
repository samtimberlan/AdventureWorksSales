using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AdventureWorksSales.Repository
{
    /// <summary>
    /// Creates or Updates information for a specified entity to DB
    /// </summary>
    public class CommandRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public CommandRepository()
        {
            _dbContext = ConnectionFactory.DbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);

        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbSet.Remove(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
