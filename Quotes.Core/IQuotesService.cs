using Quotes.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.Core
{
    public interface IQuotesService
    {
        Task<IEnumerable<Quote>> GetQuotesAsync(int? skip, int? take, string author, string category);

        Task<Quote> GetQuoteAsync(Guid id);

        Task<Quote> CreateQuoteAsync(string author, string quote, string category);

        Task UpdateQuoteAsync(Quote quote);

        Task DeleteQuoteAsync(Guid id);
    }
}