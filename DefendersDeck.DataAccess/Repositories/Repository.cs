using DefendersDeck.DataAccess.Contracts;
using DefendersDeck.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DefendersDeck.DataAccess.Repositories
{
    public class Repository<TEntity>(ApplicationDbContext context) : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

        public virtual async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.SingleOrDefaultAsync(predicate);

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
