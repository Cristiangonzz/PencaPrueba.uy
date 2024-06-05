using System.Text.Json.Serialization;

namespace WordPenca.Business.Domain
{
    public class Area
    {
        [JsonPropertyName("id")]
        public int? id { get; set; }

        [JsonPropertyName("name")]
        public string? name { get; set; }

        [JsonPropertyName("code")]
        public string? code { get; set; }

        [JsonPropertyName("flag")]
        public string? flag { get; set; }
    }
}