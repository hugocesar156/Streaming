namespace Streaming.Domain.Entities
{
    public class CatalogContent
    {
        public CatalogContent(int idContent, int? idFilm, int? idSeriesEpisode)
        {
            IdContent = idContent;
            IdFilm = idFilm;
            IdSeriesEpisode = idSeriesEpisode;
        }

        public int IdCatalogContent { get; set; }
        public int IdContent { get; set; }
        public int? IdFilm { get; set; }
        public int? IdSeriesEpisode { get; set; }
    }
}
