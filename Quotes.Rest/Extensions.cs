using Quotes.Models;
using Quotes.Rest.Dtos.Quotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Rest
{
    public static class Extensions
    {
        public static QuoteDto AsDto(this Quote quote)
        {
            return new QuoteDto
            {
                Id = quote.Id,
                Author = quote.Author,
                Category = quote.Category,
                Quote = quote.Value
            };
        } 
    }
}
