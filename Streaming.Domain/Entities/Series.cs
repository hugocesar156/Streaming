namespace Streaming.Domain.Entities
{
    public class Series
    {
        public Series(string name, string thumbnail, short year, bool kidsContent, Language language)
        {
            Name = name;
            Thumbnail = thumbnail;
            Year = year;
            KidsContent = kidsContent;
            Language = language;
            Categories = [];
            Contents = [];
            Casting = [];
            Regions = [];
        }

        public int IdSeries { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public short Year { get; set; }
        public bool KidsContent { get; set; }
        public Language Language { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Content> Contents { get; private set; }
        public List<Cast> Casting { get; private set; }
        public List<CatalogRegion> Regions { get; set; }
    }
}
