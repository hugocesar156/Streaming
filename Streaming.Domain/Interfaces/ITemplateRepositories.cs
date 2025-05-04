using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ITemplateRepositories
    {
        Task<Template> GetByName(string name, int idLanguage);
    }
}
