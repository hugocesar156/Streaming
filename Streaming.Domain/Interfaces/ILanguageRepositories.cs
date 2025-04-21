using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ILanguageRepositories
    {
        Language GetByCountryCode(string countryCode);
    }
}
