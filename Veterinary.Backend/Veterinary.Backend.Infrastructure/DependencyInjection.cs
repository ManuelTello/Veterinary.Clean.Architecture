using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Veterinary.Backend.Domain.IRepositories;
using Veterinary.Backend.Infrastructure.Persistence.Context;
using Veterinary.Backend.Infrastructure.Persistence.Repositories;

namespace Veterinary.Backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddPersistence(services,configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("VeterinaryConnection") ?? throw new NullReferenceException("Connection string is null");
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddDbContext<VeterinaryContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}

