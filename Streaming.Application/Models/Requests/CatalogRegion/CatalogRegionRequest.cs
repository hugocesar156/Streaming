using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.CatalogRegion
{
    public partial class CatalogRegionRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; init; } = string.Empty;

        [StringLength(5)]
        public string? Classification { get; init; }

        [Required]
        [StringLength(200)]
        public string Synospsis { get; init; } = string.Empty;

        [Required]
        public int IdLanguage { get; init; } 
    }
}
