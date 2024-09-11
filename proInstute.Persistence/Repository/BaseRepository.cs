
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proInstute.Domian.Interfaces;
using proInstute.Persistence.Context;
using System.Linq.Expressions;

namespace proInstute.Persistence.Repository
{
    public abstract class BaseRepository<TEntity, TType> : IRepository<TEntity, TType> where TEntity : class
    {
        private readonly InstituteDb _dbContext;
        private DbSet<TEntity> _dbSet;
        public BaseRepository(InstituteDb dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            bool result = false;

            try
            {
                result = await _dbSet.AnyAsync(filter);
            }
            catch (Exception ex)
            {
                result = false;

            }
            return result;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetEntityBy(TType Id)
        {
            return await this._dbSet.FindAsync(Id);
        }

        public virtual async Task<bool> Remove(TEntity entity)
        {
            bool result = false;
            try
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public virtual async Task<bool> Save(TEntity entity)
        {
            bool result = false;
            try
            {
                _dbSet.Add(entity);
                await _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            bool result = false;
            try
            {
                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
