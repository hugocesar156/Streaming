﻿using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class FilmRepositories : IFilmRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public FilmRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddCategories(List<CatalogCategory> request)
        {
            var entities = new List<CATALOG_CATEGORY>();

            foreach (var item in request)
            {
                entities.Add(new CATALOG_CATEGORY
                {
                    ID_FILM = item.IdFilm,
                    ID_CATEGORY = item.IdCategory
                });
            }

            _dataContext.AddRange(entities);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddContents(List<CatalogContent> request)
        {
            var entities = new List<CATALOG_CONTENT>();

            foreach (var item in request)
            {
                entities.Add(new CATALOG_CONTENT
                {
                    ID_FILM = item.IdFilm,
                    ID_CONTENT = item.IdContent
                });
            }

            _dataContext.AddRange(entities);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Audio?> FindAudio(int idFilm, int idLanguage)
        {
            var entity = await _dataContext.AUDIOs.Include(x => x.ID_LANGUAGENavigation)
                .FirstOrDefaultAsync(x => x.ID_FILM == idFilm && x.ID_LANGUAGE == idLanguage);

            if (entity is not null)
            {
                return new Audio(
                    entity.ID_AUDIO,
                    entity.PATH,
                    new Language(
                        entity.ID_LANGUAGENavigation.ID_LANGUAGE,
                        entity.ID_LANGUAGENavigation.DESCRIPTION,
                        entity.ID_LANGUAGENavigation.CODE,
                        entity.ID_LANGUAGENavigation.COUNTRY_CODE),
                    entity.ID_FILM,
                    entity.ID_SERIES_EPISODE);
            }

            return null;
        }

        public async Task<CatalogRegion?> FindFilmCatalog(int idFilm, int idLanguage)
        {
            var entity = await _dataContext.CATALOG_REGIONs.Include(x => x.ID_LANGUAGENavigation)
                .FirstOrDefaultAsync(x => x.ID_FILM == idFilm && x.ID_LANGUAGE == idLanguage);

            if (entity is not null)
            {
                return new CatalogRegion(
                    entity.ID_CATALOG_REGION,
                    entity.NAME,
                    entity.CLASSIFICATION,
                    entity.SYNOPSIS,
                    new Language(
                        entity.ID_LANGUAGENavigation.ID_LANGUAGE,
                        entity.ID_LANGUAGENavigation.DESCRIPTION,
                        entity.ID_LANGUAGENavigation.CODE,
                        entity.ID_LANGUAGENavigation.COUNTRY_CODE),
                    entity.ID_FILM,
                    entity.ID_SERIES);
            }

            return null;
        }

        public async Task<Media?> FindMedia(int idFilm, int idResolution)
        {
            var entity = await _dataContext.MEDIAs.Include(x => x.ID_RESOLUTIONNavigation)
                .FirstOrDefaultAsync(x => x.ID_FILM == idFilm && x.ID_RESOLUTION == idResolution);

            if (entity is not null)
            {
                return new Media(
                    entity.ID_MEDIA, 
                    entity.PATH, 
                    new Resolution(
                        entity.ID_RESOLUTIONNavigation.ID_RESOLUTION,
                        entity.ID_RESOLUTIONNavigation.DESCRIPTION,
                        entity.ID_RESOLUTIONNavigation.PIXELS),
                    entity.ID_FILM,
                    entity.ID_SERIES_EPISODE);
            }

            return null;
        }

        public async Task<Subtitles?> FindSubtitles(int idFilm, int idLanguage)
        {
            var entity = await _dataContext.SUBTITLEs.Include(x => x.ID_LANGUAGENavigation)
                .FirstOrDefaultAsync(x => x.ID_FILM == idFilm && x.ID_LANGUAGE == idLanguage);

            if (entity is not null) 
            {
                return new Subtitles(
                    entity.ID_SUBTITLES,
                    entity.PATH,
                     new Language(
                        entity.ID_LANGUAGENavigation.ID_LANGUAGE,
                        entity.ID_LANGUAGENavigation.DESCRIPTION,
                        entity.ID_LANGUAGENavigation.CODE,
                        entity.ID_LANGUAGENavigation.COUNTRY_CODE),
                    entity.ID_FILM,
                    entity.ID_SERIES_EPISODE);
            }

            return null;
        }

        public async Task<Film> Get(int id)
        {
            var entity = await _dataContext.FILMs
                .Include(x => x.CATALOG_CATEGORies).ThenInclude(x => x.ID_CATEGORYNavigation)
                .Include(x => x.CATALOG_CONTENTs).ThenInclude(x => x.ID_CONTENTNavigation)
                .Include(x => x.CASTs)
                .Include(x => x.ID_LANGUAGENavigation)
                .Include(x => x.CATALOG_REGIONs).ThenInclude(x => x.ID_LANGUAGENavigation)
                .Include(x => x.MEDIa).ThenInclude(x => x.ID_RESOLUTIONNavigation)
                .Include(x => x.AUDIOs).ThenInclude(x => x.ID_LANGUAGENavigation)
                .Include(x => x.SUBTITLEs).ThenInclude(x => x.ID_LANGUAGENavigation)
                .FirstOrDefaultAsync(x => x.ID_FILM == id);

            if (entity is not null)
            {
                return new Film(
                        entity.ID_FILM, 
                        entity.NAME, 
                        entity.DURATION, 
                        entity.THUMBNAIL, 
                        entity.YEAR, 
                        entity.CREDITS_START,
                        entity.KIDS_CONTENT,

                        new Language(
                            entity.ID_LANGUAGENavigation.ID_LANGUAGE, 
                            entity.ID_LANGUAGENavigation.DESCRIPTION, 
                            entity.ID_LANGUAGENavigation.CODE,
                            entity.ID_LANGUAGENavigation.COUNTRY_CODE),

                        entity.CATALOG_CATEGORies.Select(x => new Category(
                            x.ID_CATEGORYNavigation.ID_CATEGORY, 
                            x.ID_CATEGORYNavigation.NAME)).ToList(),

                        entity.CATALOG_CONTENTs.Select(x => new Content(
                            x.ID_CONTENTNavigation.ID_CONTENT, 
                            x.ID_CONTENTNavigation.DESCRIPTION)).ToList(),

                        entity.CASTs.Select(x => new Cast(
                            x.ID_CAST, 
                            x.NAME, 
                            x.CHARACTER,
                            x.ID_FILM,
                            x.ID_SERIES,
                            x.SEASON)).ToList(), 

                        entity.CATALOG_REGIONs.Select(x => new CatalogRegion(
                            x.ID_CATALOG_REGION,
                            x.NAME, 
                            x.CLASSIFICATION, 
                            x.SYNOPSIS,
                            new Language(
                                x.ID_LANGUAGENavigation.ID_LANGUAGE, 
                                x.ID_LANGUAGENavigation.DESCRIPTION, 
                                x.ID_LANGUAGENavigation.CODE, 
                                x.ID_LANGUAGENavigation.COUNTRY_CODE), 
                        entity.ID_FILM, null)).ToList(),
                        
                        entity.MEDIa.Select(x => new Media(
                            x.ID_MEDIA,
                            x.PATH,
                            new Resolution(
                                x.ID_RESOLUTIONNavigation.ID_RESOLUTION,
                                x.ID_RESOLUTIONNavigation.DESCRIPTION,
                                x.ID_RESOLUTIONNavigation.PIXELS),
                            x.ID_FILM, null)).ToList(),
                        
                        entity.AUDIOs.Select(x => new Audio(
                            x.ID_AUDIO,
                            x.PATH,
                            new Language(
                                x.ID_LANGUAGENavigation.ID_LANGUAGE,
                                x.ID_LANGUAGENavigation.DESCRIPTION,
                                x.ID_LANGUAGENavigation.CODE,
                                x.ID_LANGUAGENavigation.COUNTRY_CODE),
                            x.ID_FILM, null)).ToList(),

                        entity.SUBTITLEs.Select(x => new Subtitles(
                            x.ID_SUBTITLES,
                            x.PATH,
                            new Language(
                                x.ID_LANGUAGENavigation.ID_LANGUAGE,
                                x.ID_LANGUAGENavigation.DESCRIPTION,
                                x.ID_LANGUAGENavigation.CODE,
                                x.ID_LANGUAGENavigation.COUNTRY_CODE),
                            x.ID_FILM, null)).ToList());
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Film.NotFound, id));
        }

        public async Task<int> Insert(Film request)
        {
            var entity = new FILM
            {
                NAME = request.Name,
                DURATION = request.Duration,
                THUMBNAIL = request.Thumbnail,
                YEAR = request.Year,
                CREDITS_START = request.CreditsStart,
                KIDS_CONTENT = request.KidsContent,
                ID_LANGUAGE = request.Language.IdLanguage
            };

            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();

            return entity.ID_FILM;
        }

        public async Task RemoveCategories(List<CatalogCategory> request)
        {
            var entities = await _dataContext.CATALOG_CATEGORies
                .Where(x => x.ID_FILM == request.First().IdFilm && request.Select(x => x.IdCategory).Contains(x.ID_CATEGORY)).ToListAsync();

            _dataContext.RemoveRange(entities);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RemoveContents(List<CatalogContent> request)
        {
            var entities = await _dataContext.CATALOG_CONTENTs
                .Where(x => x.ID_FILM == request.First().IdFilm && request.Select(x => x.IdContent).Contains(x.ID_CONTENT)).ToListAsync();

            _dataContext.RemoveRange(entities);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Film request)
        {
            var entity = await _dataContext.FILMs.FirstOrDefaultAsync(x => x.ID_FILM == request.IdFilm);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Film.NotFound, request.IdFilm));
            }

            entity.NAME = request.Name;
            entity.DURATION = request.Duration;
            entity.THUMBNAIL = request.Thumbnail;
            entity.YEAR = request.Year;
            entity.CREDITS_START = request.CreditsStart;
            entity.KIDS_CONTENT = request.KidsContent;
            entity.ID_LANGUAGE = request.Language.IdLanguage;

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
