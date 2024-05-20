using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WordPenca.Business.Domain
{
    public class ChatHistorial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public Chat chat { get; set; } = null!;
        public List<ChatMensaje> Mensajes { get; set; }
        //La idea es que esta fecha coincida con la fecha del ultimo mensajes
        public DateTime UltimaActualizacion { get; set; }
    }
}
