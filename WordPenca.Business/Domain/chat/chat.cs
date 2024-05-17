using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordPenca.Business.Domain
{
    public class Chat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? imagen { get; set; }
        public string? Description { get; set; }
        public ChatHistorial Historial { get; set; } = null!;
        public List<string> Usuarios { get; set; } = null!;//Por correos
        public bool privado { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
