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
            services.AddScoped<IEmailSenderRepositories, EmailSenderRepositories>();
            services.AddScoped<IFilmRepositories, FilmRepositories>();
            services.AddScoped<ILanguageRepositories, LanguageRepositories>();
            services.AddScoped<IMediaRepositories, MediaRepositories>();
            services.AddScoped<IProfileRepositories, ProfileRepositories>();
            services.AddScoped<ITemplateRepositories, TemplateRepositories>();
            services.AddScoped<ISeriesEpisodeRepositories, SeriesEpisodeRepositories>();
            services.AddScoped<ISeriesRepositories, SeriesRepositories>();
            services.AddScoped<ISubtitlesRepositories, SubtitlesRepositories>();
            services.AddScoped<IUserRepositories, UserRepositories>();

            return services;
        }
    }
}
