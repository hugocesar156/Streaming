namespace Streaming.Shared
{
    public static class ErrorMessages
    {
        public const string FieldRequired = "The field '{0}' is required.";
        public const string RegisterNotFound = "Register not found.";
        public const string StringLength = "The field '{0}' requires a maximum {1} string length.";

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
            public const string NotFound = "Film '{0}' not found.";
        }
    }
}
