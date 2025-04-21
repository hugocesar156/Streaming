namespace Streaming.Domain.Entities
{
    public class Language
    {
        public Language(int idLanguage)
        {
            IdLanguage = idLanguage;
            Description = string.Empty;
            Code = string.Empty;
            CountryCode = string.Empty;
        }

        public Language(int idLanguage, string description, string code, string countryCode)
        {
            IdLanguage = idLanguage;
            Description = description;
            Code = code;
            CountryCode = countryCode;
        }

        public int IdLanguage { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }
        public string CountryCode { get; private set; }
    }
}
