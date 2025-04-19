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
            services.AddScoped<ICategoryUseCase, CategoryUseCase>();
            services.AddScoped<IContentUseCase, ContentUseCase>();
            services.AddScoped<IFilmUseCase, FilmUseCase>();

            return services;
        }
    }
}
