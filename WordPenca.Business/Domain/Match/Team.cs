using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Team
    {
        [BsonId]
        [JsonPropertyName("id")]
        public int? id { get; set; }

        [JsonPropertyName("name")]
        public string? name { get; set; }

        [JsonPropertyName("shortName")]
        public string? shortName { get; set; }

        [JsonPropertyName("tla")]
        public string? tla { get; set; }

        [JsonPropertyName("crest")]
        public string? crest { get; set; }
    }
}