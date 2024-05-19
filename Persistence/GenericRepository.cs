using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>[]? includes = null, CancellationToken cancellationToken = default)
        {
            var data = expression == null ? _dbSet.AsQueryable() : _dbContext.Set<T>().Where(expression);

            if (includes != null)
            {
                data = includes.Aggregate(data, (item, include) => item.Include(include));
            }

            return await data.ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }


        public async Task AddAsync(T obj, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(obj, cancellationToken);
            _dbContext.Entry(obj).State = EntityState.Added;
        }


        public void Update(T obj)
        {
            _dbSet.Update(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }

        public async Task Delete(T? entity)
        {
            var data = await _dbSet.FindAsync(entity);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }
    }
}