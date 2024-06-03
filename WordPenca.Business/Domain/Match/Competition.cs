using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Competition
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Emblem { get; set; }
    }
}