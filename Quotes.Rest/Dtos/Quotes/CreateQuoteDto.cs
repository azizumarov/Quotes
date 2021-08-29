using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
