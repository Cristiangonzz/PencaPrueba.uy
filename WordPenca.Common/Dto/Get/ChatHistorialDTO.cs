using System.ComponentModel.DataAnnotations;

namespace WordPenca.Common.Dto
{
    public class ChatHistorialDTO
    {

        [Required]
        public string idHistorial { get; set; }
        public List<string>? mensajes { get; set; }
    }
}
