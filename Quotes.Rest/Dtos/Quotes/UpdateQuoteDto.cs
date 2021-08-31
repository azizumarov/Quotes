using System.ComponentModel.DataAnnotations;

namespace Quotes.Rest.Dtos.Quotes
{
    public class UpdateQuoteDto
    {
        [Required] public string Quote { get; set; }

        [Required] public string Category { get; set; }
    }
}