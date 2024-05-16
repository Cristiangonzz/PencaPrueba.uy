using System.ComponentModel.DataAnnotations;

namespace WordPenca.Common.Dto
{
    public class ChatDTO
    {

        [Required]
        public string? Name { get; set; }
        public string? imagen { get; set; }
        public string? Description { get; set; }
    }
}
