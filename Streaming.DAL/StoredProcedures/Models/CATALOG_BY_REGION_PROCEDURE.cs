namespace Streaming.DAL.StoredProcedures.Models
{
    public class CATALOG_BY_REGION_PROCEDURE
    {
        public string NAME { get; init; } = string.Empty;
        public string SYNOPSIS { get; init; } = string.Empty;
        public int? ID_FILM { get; init; }
        public int? ID_SERIES { get; init; }
        public string THUMBNAIL { get; init; } = string.Empty;
        public string? CATEGORIES { get; init; } = string.Empty;
        public int TOTAL { get; init; }
    }
}
