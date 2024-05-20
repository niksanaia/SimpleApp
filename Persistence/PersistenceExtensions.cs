using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        return serviceCollection;
    }
}