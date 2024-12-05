using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Veterinary.Backend.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                var assembly = typeof(DependencyInjection).Assembly ?? throw new NullReferenceException(nameof(Assembly));
                options.AddMaps(assembly);
            });
            return services;
        }
    }
}

