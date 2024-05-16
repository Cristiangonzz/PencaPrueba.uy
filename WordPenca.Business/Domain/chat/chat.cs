namespace WordPenca.Business.Domain
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? imagen { get; set; }
        public string? Description { get; set; }
        public ChatHistorial Historial { get; set; } = null!;
        public List<Usuario> Usuarios { get; set; }

        public bool privado { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
