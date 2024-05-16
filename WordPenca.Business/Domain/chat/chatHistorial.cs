namespace WordPenca.Business.Domain
{
    public class ChatHistorial
    {
        public Guid Id { get; set; }
        public Chat chat { get; set; } = null!;
        public List<ChatMensaje> Mensajes { get; set; }
        //La idea es que esta fecha coincida con la fecha del ultimo mensajes
        public DateTime UltimaActualizacion { get; set; }
    }
}
