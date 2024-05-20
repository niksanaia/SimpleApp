using Domain;

namespace Persistence;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;
    private readonly Dictionary<Type, object> _repositories = new();

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new GenericRepository<TEntity>(_context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}