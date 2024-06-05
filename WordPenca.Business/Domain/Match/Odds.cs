using System.Text.Json.Serialization;

namespace WordPenca.Business.Domain
{
    public class Odds
    {
        [JsonPropertyName("msg")]
        public string? msg { get; set; }
    }
}