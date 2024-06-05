using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Match
    {
        [BsonId]
        [JsonPropertyName("id")]
        public int? id { get; set; }

        [JsonPropertyName("area")]
        public Area? area { get; set; }

        [JsonPropertyName("competition")]
        public Competition? competition { get; set; }

        [JsonPropertyName("season")]
        public Season? season { get; set; }

        [JsonPropertyName("utcDate")]
        public string? utcDate { get; set; }

        [JsonPropertyName("status")]
        public string? status { get; set; }

        [JsonPropertyName("matchday")]
        public int? matchday { get; set; }

        [JsonPropertyName("stage")]
        public string? stage { get; set; }

        [JsonPropertyName("group")]
        public object? group { get; set; }

        [JsonPropertyName("lastUpdated")]
        public string? lastUpdated { get; set; }

        [JsonPropertyName("homeTeam")]
        public Team? homeTeam { get; set; }

        [JsonPropertyName("awayTeam")]
        public Team? awayTeam { get; set; }

        [JsonPropertyName("score")]
        public Score? score { get; set; }

        [JsonPropertyName("odds")]
        public Odds? odds { get; set; }

        [JsonPropertyName("referees")]
        public List<Referee>? referees { get; set; }
    }
}