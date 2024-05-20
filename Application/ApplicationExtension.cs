using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public  static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return service;
    }
}