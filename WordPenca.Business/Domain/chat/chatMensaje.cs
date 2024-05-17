using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordPenca.Business.Domain
{
    public class ChatMensaje
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string mensaje { get; set; } = null!;
        public string? RespuestaMensaje { get; set; }//Para indicarle si es una respuesta de un mensaje especifico
        public bool activo { get; set; } = false;
        public string? Description { get; set; }
        public string Usuario { get; set; } = null!;
        public DateTime CreationDate { get; set; } //Es el que le va dar orden al chat

    }
}
