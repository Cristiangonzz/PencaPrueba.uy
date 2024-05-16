namespace WordPenca.Business.Domain
{
    public class ChatMensaje 
    {

        public Guid Id { get; set; }
        public string mensaje { get; set; } = null!;
        public string? RespuestaMensaje { get; set; }//Para indicarle si es una respuesta de un mensaje especifico
        public bool activo { get; set; } = false; 
        public string? Description { get; set;}
        public Usuario Usuario { get; set; }
        public DateTime CreationDate { get; set;} //Es el que le va dar orden al chat

    }
}
