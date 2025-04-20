namespace Streaming.Application.Models.Responses
{
    public class LanguageResponse
    {
        public LanguageResponse(int idLanguage, string description, string code)
        {
            IdLanguage = idLanguage;
            Description = description;
            Code = code;
        }

        public int IdLanguage { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
