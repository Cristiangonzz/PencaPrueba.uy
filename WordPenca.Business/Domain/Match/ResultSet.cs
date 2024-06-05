using System.Text.Json.Serialization;

namespace WordPenca.Business.Domain
{
    public class ResultSet
    {
        [JsonPropertyName("count")]
        public int? count { get; set; }

        [JsonPropertyName("competitions")]
        public string? competitions { get; set; }

        [JsonPropertyName("first")]
        public string? first { get; set; }

        [JsonPropertyName("last")]
        public string? last { get; set; }

        [JsonPropertyName("played")]
        public int? played { get; set; }
    }
}