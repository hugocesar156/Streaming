using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.SeriesEpisode;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class SeriesEpisodeUseCase : ISeriesEpisodeUseCase
    {
        private readonly ISeriesEpisodeRepositories _seriesEpisodeRepositories;
        private readonly ISeriesRepositories _seriesRepositories;

        public SeriesEpisodeUseCase(ISeriesEpisodeRepositories seriesEpisodeRepositories, ISeriesRepositories seriesRepositories)
        {
            _seriesEpisodeRepositories = seriesEpisodeRepositories;
            _seriesRepositories = seriesRepositories;
        }

        public void Insert(SeriesEpisodeInsertRequest request)
        {
            try
            {
                _seriesRepositories.Get(request.IdSeries);

                var seriesEpisode = new SeriesEpisode(request.Name, request.Thumbnail, request.Synopsis, request.Season,
                    request.Episode, request.Duration, request.Year, request.OpeningStart, request.CreditsStart, request.IdSeries);

                if (_seriesEpisodeRepositories.FindSeriesEpisode(request.IdSeries, request.Season, request.Episode) is not null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.SeriesEpisode.EpisodeSeries);
                }

                _seriesEpisodeRepositories.Insert(seriesEpisode);
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
