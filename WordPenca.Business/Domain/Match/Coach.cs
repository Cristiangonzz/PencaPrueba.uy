using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class Coach
    {

        public int? id { get; set; }
        public string? name { get; set; }
        public string? nationality { get; set; }
    }
}