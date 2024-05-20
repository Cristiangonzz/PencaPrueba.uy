using System.ComponentModel.DataAnnotations;

namespace WordPenca.Common.Dto
{
    public class ChatMensajeDTO
    {
        [Required]
        public string chatId { get; set; } = null!;

        [Required]
        public string mensaje { get; set; } = null!;
        public string? usuario { get; set; } // por momento


    }
}
