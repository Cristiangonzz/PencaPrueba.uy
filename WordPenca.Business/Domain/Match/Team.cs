using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Team
    {
        [BsonId]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? Tla { get; set; }
        public string? Crest { get; set; }
    }
}