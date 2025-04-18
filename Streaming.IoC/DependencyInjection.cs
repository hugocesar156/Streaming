using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Streaming.DAL.Context;

namespace Streaming.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StreamingDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("Streaming") ?? string.Empty), ServiceLifetime.Transient);

            services.AddUseCases(configuration);
            services.AddRepositories(configuration);

            return services;
        }
    }
}
