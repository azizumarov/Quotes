using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Rest.Dtos.Quotes
{
    public class QuoteDto
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Quote { get; set; }
    }
}
