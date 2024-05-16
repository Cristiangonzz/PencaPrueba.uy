using System.ComponentModel.DataAnnotations;

namespace WordPenca.Common.Dto
{
    public class UsuarioDTO
    {

        [Required]
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

    }
}
