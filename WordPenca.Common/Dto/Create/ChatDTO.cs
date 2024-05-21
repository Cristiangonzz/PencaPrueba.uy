using System.ComponentModel.DataAnnotations;

namespace WordPenca.Common.Dto
{
    public class ChatDTO
    {
        [Required]
        public string usuarioCreadorId { get; set; } = null!;
        [Required]
        public string usuarioInvitadoId { get; set; } = null!;
        public string? Name { get; set; }
        [Required]
        public bool Privado { get; set; }
        public string? Description { get; set; }


    }
}
