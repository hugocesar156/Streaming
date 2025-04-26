namespace Streaming.Shared
{
    public static class ErrorMessages
    {
        public const string ActionNotAllowed = "Action not allowed.";
        public const string AddressIPClient = "Failed to get IP address data.";
        public const string ClientIPNotFound = "Client IP not found.";
        public const string FieldRequired = "The field '{0}' is required.";
        public const string InternalServerError = "Internal server error.";
        public const string InvalidTime = "The time value of '{0}' must be less then '{1}' time value.";
        public const string InvalidTimeFormat = "Invalid time format for '{0}'.";
        public const string RegisterNotFound = "Register not found.";
        public const string StringLength = "The field '{0}' requires a maximum {1} string length.";

        public static class Cast
        {
            public const string NotFound = "Cast '{0}' not found.";
        }

        public static class Category
        {
            public const string NotFound = "Category '{0}' not found.";
        }

        public static class Content
        {
            public const string NotFound = "Content '{0}' not found.";
        }

        public static class Film
        {
            public const string Audio = "Audio in this language already exists for this film.";
            public const string Media = "Already has a media in this resolution for this film.";
            public const string NotFound = "Film '{0}' not found.";
            public const string RegionCatalog = "This film already exists in the catalog for this region.";
            public const string Subtitles = "Subtitles in this language already exists for this film.";
        }

        public static class Language
        {
            public const string CountryCodeNotFound = "Country code not found.";
        }

        public static class Series
        {
            public const string NotFound = "Series '{0}' not found.";
            public const string RegionCatalog = "This series already exists in the catalog for this region.";
        }

        public static class SeriesEpisode
        {
            public const string NotFound = "Series episode '{0}' not found.";
            public const string EpisodeSeries = "Episode already exists for this series.";
        }
    }
}
