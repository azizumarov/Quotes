using System.ComponentModel.DataAnnotations;

namespace Quotes.Rest.Dtos.Quotes
{
    public class CreateQuoteDto
    {
        [Required]
        public string Author { get; set; }

        [Required]
        public string Quote { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
