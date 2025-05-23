﻿using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Domain.StoredProcedures;

namespace Streaming.DAL.Repositories
{
    public class CatalogRegionRepositories : ICatalogRegionRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public CatalogRegionRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CatalogByRegionProcedure?> Get(int pageNumber, int pageSize, int idLanguage, int idCategory, bool kidsContent, string search)
        {
            var entities = await _dataContext.SP_CATALOG_BY_REGION
                .FromSql($"EXEC sp_GetCatalogByRegion {pageNumber},{pageSize},{idLanguage},{idCategory},{kidsContent},{search}").ToListAsync();

            if (entities.Any())
            {
                var catalog = entities.Select(x => new CatalogByRegion(x.NAME, x.SYNOPSIS, x.ID_FILM, x.ID_SERIES, x.THUMBNAIL, x.CATEGORIES)).ToList();
                int total = entities.First().TOTAL;

                var response = new CatalogByRegionProcedure(
                    catalog,
                    pageNumber,
                    pageSize,
                    int.Parse(Math.Ceiling(double.Parse(total.ToString()) / double.Parse(pageSize.ToString())).ToString()),
                    total);

                return response;
            }

            return null;
        }

        public async Task Insert(CatalogRegion request)
        {
            var entity = new CATALOG_REGION
            {
                NAME = request.Name,
                CLASSIFICATION = request.Classification,
                SYNOPSIS = request.Synopsis,
                ID_LANGUAGE = request.Language.IdLanguage,
                ID_FILM = request.IdFilm,
                ID_SERIES = request.IdSeries
            };

            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
