
namespace WordPenca.Business.Domain
{
    public class Usuario
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? URLFotoPerfil { get; set; }

        public string? Role { get; set; }
        public DateTime CreationDate { get; set; }
      

        public List<Chat>? Chat { get; set; }

        public List<ChatMensaje>? Mensajes { get; set; }

    }
}
