using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Player
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? position { get; set; }
        public int? shirtNumber { get; set; }
    }
}