using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Streaming.Application.Interfaces;
using Streaming.Application.UseCases;

namespace Streaming.IoC
{
    public static class UseCaseInjections
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAudioUseCase, AudioUseCase>();
            services.AddScoped<ICastUseCase, CastUseCase>();
            services.AddScoped<ICatalogRegionUseCase, CatalogRegionUseCase>();
            services.AddScoped<ICategoryUseCase, CategoryUseCase>();
            services.AddScoped<IContentUseCase, ContentUseCase>();
            services.AddScoped<IFilmUseCase, FilmUseCase>();
            services.AddScoped<ILogUseCase, LogUseCase>();
            services.AddScoped<IProfileUseCase, ProfileUseCase>();
            services.AddScoped<ISeriesEpisodeUseCase, SeriesEpisodeUseCase>();
            services.AddScoped<ISeriesUseCase, SeriesUseCase>();
            services.AddScoped<IUserUseCase, UserUseCase>();

            return services;
        }
    }
}
