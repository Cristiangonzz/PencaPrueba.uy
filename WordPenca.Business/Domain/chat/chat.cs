using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
         [JsonIgnore]
        public ChatHistorial Historial { get; set; }
        public List<ChatUsuario> Usuarios { get; set; } = null!;//Por correos
        public bool privado { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
