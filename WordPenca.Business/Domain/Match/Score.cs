using System.Text.Json.Serialization;

namespace WordPenca.Business.Domain
{

    public class Score
    {
        [JsonPropertyName("winner")]
        public string? winner { get; set; }

        [JsonPropertyName("duration")]
        public string? duration { get; set; }

        [JsonPropertyName("fullTime")]
        public ScoreTime? fullTime { get; set; }

        [JsonPropertyName("halfTime")]
        public ScoreTime? halfTime { get; set; }
    }
}