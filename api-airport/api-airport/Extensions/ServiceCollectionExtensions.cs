using System.Reflection;

namespace api_airport.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var implementationTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Repository"))
            .ToList();

        foreach (var implementationType in implementationTypes)
        {
            var interfaceTypes = implementationType.GetInterfaces()
                .Where(i => i.Name == $"I{implementationType.Name}" || i.IsGenericType) 
                .ToList();

            foreach (var interfaceType in interfaceTypes)
            {
                Console.WriteLine($"Registering {interfaceType} -> {implementationType}");
                services.AddScoped(interfaceType, implementationType);
            }
        }
    }

    public static void AddMappers(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var mapperTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Mapper"))
            .ToList();

        foreach (var mapperType in mapperTypes)
        {
            var interfaceType = mapperType.GetInterfaces()
                .FirstOrDefault(type => type.Name.StartsWith("IMapper"));

            if (interfaceType != null)
            {
                Console.WriteLine($"Adding scoped mapper: {interfaceType.Name}, {mapperType.Name}");
                services.AddScoped(interfaceType, mapperType);
            }
        }
    }

    public static void AddServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var serviceTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Service"))
            .ToList();

        foreach (var serviceType in serviceTypes)
        {
            var interfaceType = serviceType.GetInterfaces()
                .FirstOrDefault(type => type.Name == $"I{serviceType.Name}");

            if (interfaceType != null)
            {
                Console.WriteLine($"Adding scoped service: {interfaceType.Name}, {serviceType.Name}");
                services.AddScoped(interfaceType, serviceType);
            }
        }
    }
}
