using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class EmailSenderRepositories : IEmailSenderRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public EmailSenderRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<EmailSender> Get()
        {
            var entity = await _dataContext.EMAIL_SENDERs.FirstOrDefaultAsync();

            if (entity is not null)
            {
                return new EmailSender(entity.ID_EMAIL_SENDER, entity.EMAIL, entity.PASSWORD, entity.SMTP, entity.PORT, entity.SSL);
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, ErrorMessages.EmailSender.NotFound);
        }
    }
}
