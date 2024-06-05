using System.Text.Json.Serialization;

namespace WordPenca.Business.Domain
{
    public class ScoreTime
    {
        [JsonPropertyName("home")]
        public int? home { get; set; }

        [JsonPropertyName("away")]
        public int? away { get; set; }
    }
}