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
            services.AddScoped<IAudioRepositories, AudioRepositories>();
            services.AddScoped<ICastRepositories, CastRepositories>();
            services.AddScoped<ICatalogRegionRepositories, CatalogRegionRepositories>();
            services.AddScoped<ICategoryRepositories, CategoryRepositories>();
            services.AddScoped<IContentRepositories, ContentRepositories>();
            services.AddScoped<IFilmRepositories, FilmRepositories>();
            services.AddScoped<IMediaRepositories, MediaRepositories>();
            services.AddScoped<ISubtitlesRepositories, SubtitlesRepositories>();

            return services;
        }
    }
}
