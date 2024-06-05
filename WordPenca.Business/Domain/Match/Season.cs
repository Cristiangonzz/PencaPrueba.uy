using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Season
    {
        [JsonPropertyName("id")]
        public int? id { get; set; }

        [JsonPropertyName("startDate")]
        public string? startDate { get; set; }

        [JsonPropertyName("endDate")]
        public string? endDate { get; set; }

        [JsonPropertyName("currentMatchday")]
        public int? currentMatchday { get; set; }

        [JsonPropertyName("winner")]
        public object? winner { get; set; }
    }

}