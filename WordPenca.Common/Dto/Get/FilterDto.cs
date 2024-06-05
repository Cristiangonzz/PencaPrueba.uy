using System.ComponentModel.DataAnnotations;

namespace WordPenca.Common.Dto
{
    public class FilterDTO
    {

        [Required]
        public string dateTo { get; set; }
        [Required]
        public string dateFrom { get; set; }


    }
}
