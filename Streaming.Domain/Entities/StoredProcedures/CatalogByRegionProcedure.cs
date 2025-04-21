namespace Streaming.Domain.Entities.SoredProcedures
{
    public class CatalogByRegionProcedure
    {
        public CatalogByRegionProcedure(List<CatalogByRegion> catalog, int currentPage, int pageSize, int lastPage, int total)
        {
            Response = catalog;
            CurrentPage = currentPage;
            PageSize = pageSize;
            LastPage = lastPage;
            Total = total;
        }

        public List<CatalogByRegion> Response { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int LastPage { get; private set; }
        public int Total { get; private set; }
    }

    public partial class CatalogByRegion
    {
        public CatalogByRegion(string name, string synopsis, int? idFilm, int? idSeries, string thumbnail, string? categories)
        {
            Name = name;
            Synopsis = synopsis;
            IdFim = idFilm;
            IdSeries = idSeries;
            Thumbnail = thumbnail;

            if (categories is not null)
            {
                Categories = categories.Split("|").Select(x => new Categories(int.Parse(x.Split("-")[0]), x.Split("-")[1])).ToList();
            }
            else
                Categories = [];
        }

        public string Name { get; private set; } 
        public string Synopsis { get; private set; } 
        public int? IdFim { get; private set; }
        public int? IdSeries { get; private set; }
        public string Thumbnail { get; private set; } 
        public List<Categories> Categories { get; private set; }
    }

    public partial class Categories
    {
        public Categories(int idCategory, string name)
        {
            IdCategory = idCategory;
            Name = name;
        }

        public int IdCategory { get; private set; }
        public string Name { get; private set; }
    }
}
