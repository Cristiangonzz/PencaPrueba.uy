using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class RootMatch
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public string? id { get; set; }

        [JsonPropertyName("filters")]
        public Filter filters { get; set; } = null!;

        [JsonPropertyName("resultSet")]
        public ResultSet resultSet { get; set; } = null!;

        [JsonPropertyName("matches")]
        public List<Match> matches { get; set; } = null!;
    }
}