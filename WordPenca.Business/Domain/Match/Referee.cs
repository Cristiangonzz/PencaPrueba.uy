using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Referee
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("nationality")]
        public string? Nationality { get; set; }
    }
}