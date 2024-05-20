
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WordPenca.Business.Domain
{
    public class ChatUsuario 
    {

        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public List<string> Chats { get; set; } = new List<string> { }; // Le pongo string para llevarlo para sql
    }
}
