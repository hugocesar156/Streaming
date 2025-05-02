using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class LanguageRepositories : ILanguageRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public LanguageRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Language> GetByCountryCode(string countryCode)
        {
            var entity = await _dataContext.LANGUAGEs.FirstOrDefaultAsync(x => x.COUNTRY_CODE.ToUpper().Equals(countryCode.ToUpper()));

            if (entity is not null)
            {
                return new Language(entity.ID_LANGUAGE, entity.DESCRIPTION, entity.CODE, entity.COUNTRY_CODE);
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, ErrorMessages.Language.CountryCodeNotFound);
        }
    }
}
