using Streaming.Application.Models.Responses.Category;

namespace Streaming.Application.Models.Responses.CatalogRegion
{
    public class CatalogRegionPageResponse
    {
        public CatalogRegionPageResponse()
        {
            Response = [];
            CurrentPage = 0;
            PageSize = 0;
            LastPage = 0;
            Total = 0;
        }

        public CatalogRegionPageResponse(List<CatalogRegionPage> catalogRegion, int currentPage, int pageSize, int lastPage, int total)
        {
            Response = catalogRegion;
            CurrentPage = currentPage;
            PageSize = pageSize;
            LastPage = lastPage;
            Total = total;
        }

        public List<CatalogRegionPage> Response { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int LastPage { get; private set; }
        public int Total { get; private set; }
    }

    public partial class CatalogRegionPage
    {
        public CatalogRegionPage(string name, string synopsis, int? idFilm, int? idSeries, string thumbnail, List<CategoryResponse> categories)
        {
            Name = name;
            Synopsis = synopsis;
            IdFim = idFilm;
            IdSeries = idSeries;
            Thumbnail = thumbnail;
            Categories = categories;
        }

        public string Name { get; private set; }
        public string Synopsis { get; private set; }
        public int? IdFim { get; private set; }
        public int? IdSeries { get; private set; }
        public string Thumbnail { get; private set; }
        public List<CategoryResponse> Categories { get; private set; }
    }
}
