using System.Text.Json.Serialization;

namespace WordPenca.Business.Domain
{
    public class Filter
    {
        [JsonPropertyName("dateFrom")]
        public string? dateFrom { get; set; }

        [JsonPropertyName("dateTo")]
        public string? dateTo { get; set; }

        [JsonPropertyName("permission")]
        public string? permission { get; set; }
    }
}