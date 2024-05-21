using System.ComponentModel.DataAnnotations;

namespace WordPenca.Common.Dto
{
    public class ChatMensajeDTO
    {
        [Required]
        public string chatId { get; set; } = null!;

        [Required]
        public string mensaje { get; set; } = null!;

        [Required]
        public string usuarioName { get; set; } = null!;
        [Required]
        public string usuario { get; set; } = null!; // por momento


    }
}
