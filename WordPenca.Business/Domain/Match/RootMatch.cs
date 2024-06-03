using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class RootMatch
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Filter Filters { get; set; } = null!;
        public ResultSet ResultSet { get; set; } = null!;
        public List<Match> Matches { get; set; } = new List<Match>();
    }
}