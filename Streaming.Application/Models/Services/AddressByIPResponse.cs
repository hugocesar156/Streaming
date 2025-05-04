using Newtonsoft.Json;

namespace Streaming.Application.Models.Services
{
    public class AddressByIPResponse
    {
        [JsonProperty("status")]
        public string Status { get; init; } = string.Empty;

        [JsonProperty("country")]
        public string Country { get; init; } = string.Empty;

        [JsonProperty("countryCode")]
        public string CountryCode { get; init; } = string.Empty;

        [JsonProperty("region")]
        public string Region { get; init; } = string.Empty;

        [JsonProperty("regionName")]
        public string RegionName { get; init; } = string.Empty;

        [JsonProperty("city")]
        public string City { get; init; } = string.Empty;

        [JsonProperty("zip")]
        public string Zip { get; init; } = string.Empty;

        [JsonProperty("lat")]
        public double Lat { get; init; } 

        [JsonProperty("lon")]
        public double Lon { get; init; }

        [JsonProperty("timezone")]
        public string Timezone { get; init; } = string.Empty;

        [JsonProperty("isp")]
        public string Isp { get; init; } = string.Empty;

        [JsonProperty("org")]
        public string Org { get; init; } = string.Empty;

        [JsonProperty("as")]
        public string As { get; init; } = string.Empty;

        [JsonProperty("query")]
        public string Query { get; init; } = string.Empty;
    }
}
