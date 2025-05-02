using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ILanguageRepositories
    {
        Task<Language> GetByCountryCode(string countryCode);
    }
}
