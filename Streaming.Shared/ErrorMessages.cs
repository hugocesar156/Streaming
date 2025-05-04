namespace Streaming.Shared
{
    public static class ErrorMessages
    {
        public const string ActionNotAllowed = "Action not allowed.";
        public const string AddressIPClient = "Failed to get IP address data.";
        public const string ClientIPNotFound = "Client IP not found.";
        public const string FieldRequired = "The field '{0}' is required.";
        public const string InternalServerError = "Internal server error.";
        public const string InvalidEmailAddres = "Invalid e-mail address.";
        public const string InvalidTime = "The time value of '{0}' must be less then '{1}' time value.";
        public const string InvalidTimeFormat = "Invalid time format for '{0}'.";
        public const string RegisterNotFound = "Register not found.";
        public const string StringLength = "The field '{0}' requires a maximum {1} string length.";

        public static class Audio
        {
            public const string NotFound = "Audio '{0}' not found.";
        }

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

        public static class EmailSender
        {
            public const string NotFound = "Failed to get email sender configuration.";
        }

        public static class Film
        {
            public const string Audio = "Audio in this language already exists for this film.";
            public const string Media = "Already has a media in this resolution for this film.";
            public const string NotFound = "Film '{0}' not found.";
            public const string NotFoundInCatalog = "Film '{0}' not found in catalog list.";
            public const string RegionCatalog = "This film already exists in the catalog for this region.";
            public const string Subtitles = "Subtitles in this language already exists for this film.";
        }

        public static class Language
        {
            public const string CountryCodeNotFound = "Country code not found.";
        }

        public static class Profile
        {
            public const string NotFound = "Profile '{0}' not found.";
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

        public static class Template
        {
            public const string NotFound = "Template '{0}' not found in this region.";
        }

        public static class User
        {
            public const string EmailNotFound = "E-mail not found.";
            public const string InvalidEmail = "E-mail already registred.";
            public const string NotFound = "User '{0}' not found.";
            public const string WrongPassword = "Wrong passowrd.";
        }
    }
}
