using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class TemplateRepositories : ITemplateRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public TemplateRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Template> GetByName(string name, int idLanguage)
        {
            var entity = await _dataContext.TEMPLATEs
                .Include(x => x.TEMPLATE_CONTENTs).ThenInclude(x => x.ID_LANGUAGENavigation)
                .Include(x => x.TEMPLATE_VARIABLEs)
                .FirstOrDefaultAsync(x => x.NAME.Equals(name) && x.TEMPLATE_CONTENTs.Any(x => x.ID_LANGUAGE == idLanguage));

            if (entity is not null)
            {
                return new Template(
                    entity.ID_TEMPLATE,
                    entity.NAME,

                    entity.TEMPLATE_CONTENTs.Select(x => new TemplateContent(
                        x.ID_TEMPLATE_CONTENT,
                        x.NAME,
                        x.CONTENT,
                        x.ID_TEMPLATE,
                        new Language(
                            x.ID_LANGUAGENavigation.ID_LANGUAGE,
                            x.ID_LANGUAGENavigation.DESCRIPTION,
                            x.ID_LANGUAGENavigation.CODE,
                            x.ID_LANGUAGENavigation.COUNTRY_CODE))).ToList(),
                    
                    entity.TEMPLATE_VARIABLEs.Select(x => new TemplateVariable(
                        x.ID_TEMPLATE_VARIABLES,
                        x.NAME,
                        x.POSITION,
                        x.ID_TEMPLATE)).ToList());
            }

            throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, string.Format(ErrorMessages.Template.NotFound, name));
        }
    }
}
