using Quotes.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.Repositories
{
    public interface IQuotesRepository
    {
        Task<IEnumerable<Quote>> GetQuotesAsync();

        Task<Quote> GetQuoteAsync(Guid id);

        Task<Quote> CreateQuoteAsync(string author, string value, string category);

        Task UpdateQuoteAsync(Quote quote);

        Task DeleteQuoteAsync(Guid id);

    }
}