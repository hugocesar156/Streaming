using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.CatalogRegion
{
    public partial class CatalogRegion
    {
        [Required]
        public string Name { get; init; } = string.Empty;

        [Required]
        public string Classification { get; init; } = string.Empty;

        [Required]
        public string Synospsis { get; init; } = string.Empty;

        [Required]
        public int IdLanguage { get; init; } 
    }
}
