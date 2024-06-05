using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Competition
    {
        [JsonPropertyName("id")]
        public int? id { get; set; }

        [JsonPropertyName("name")]
        public string? name { get; set; }

        [JsonPropertyName("code")]
        public string? code { get; set; }

        [JsonPropertyName("type")]
        public string? type { get; set; }

        [JsonPropertyName("emblem")]
        public string? emblem { get; set; }
    }

}