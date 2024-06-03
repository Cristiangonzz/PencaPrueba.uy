using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Player
    {
        [BsonId]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public int? ShirtNumber { get; set; }
    }
}