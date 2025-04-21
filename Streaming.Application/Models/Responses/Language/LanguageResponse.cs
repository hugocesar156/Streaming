namespace Streaming.Application.Models.Responses.Language
{
    public class LanguageResponse
    {
        public LanguageResponse(int idLanguage, string description, string code, string countryCode)
        {
            IdLanguage = idLanguage;
            Description = description;
            Code = code;
            CountryCode = countryCode;
        }

        public int IdLanguage { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string CountryCode { get; set; }
    }
}
