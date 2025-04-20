using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Streaming.DAL.Repositories;
using Streaming.Domain.Interfaces;

namespace Streaming.IoC
{
    public static class RepositoriesInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICastRepositories, CastRepositories>();
            services.AddScoped<ICategoryRepositories, CategoryRepositories>();
            services.AddScoped<IContentRepositories, ContentRepositories>();
            services.AddScoped<IFilmRepositories, FilmRepositories>();

            return services;
        }
    }
}
