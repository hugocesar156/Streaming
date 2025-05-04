using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IEmailSenderRepositories
    {
        Task<EmailSender> Get();
    }
}
