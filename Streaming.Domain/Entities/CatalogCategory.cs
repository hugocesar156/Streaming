namespace Streaming.Domain.Entities
{
    public class CatalogCategory
    {
        public CatalogCategory(int idCategory, int? idFilm, int? idSeries)
        {
            IdCategory = idCategory;
            IdFilm = idFilm;
            IdSeries = idSeries;
        }

        public int IdCatalogCategory { get; set; }
        public int IdCategory { get; set; }
        public int? IdFilm { get; set; }
        public int? IdSeries { get; set; }
    }
}
