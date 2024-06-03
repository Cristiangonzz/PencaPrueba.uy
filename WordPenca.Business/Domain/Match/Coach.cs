using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Coach
    {
        [BsonId]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Nationality { get; set; }
    }
}