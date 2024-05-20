using System.ComponentModel.DataAnnotations;

namespace WordPenca.Common.Dto
{
    public class ChatDTO
    {
        public string usuarioCreadorId { get; set; }
        public string? usuarioInvitadoId { get; set; }
        public string? Name { get; set; }
        [Required]
        public bool Privado { get; set; }
        public string? Description { get; set; }


    }
}
