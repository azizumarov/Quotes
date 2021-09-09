using System;

namespace Quotes.Rest.Dtos.Quotes
{
    public class QuoteDto
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public string Quote { get; set; }

        public string Category { get; set; }
    }
}