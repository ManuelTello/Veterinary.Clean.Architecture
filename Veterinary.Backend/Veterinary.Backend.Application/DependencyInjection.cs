using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Veterinary.Backend.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly ?? throw new NullReferenceException(nameof(Assembly));
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(assembly);
            });
            return services;
        }
    }
}

