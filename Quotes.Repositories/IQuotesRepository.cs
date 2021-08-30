using Quotes.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.Repositories
{
    public interface IQuotesRepository
    {
        Task<IEnumerable<Quote>> GetQuotes();

        Task<Quote> GetQuote(Guid id);

        Task<Quote> CreateQuote(string author, string value, string category);

        Task UpdateQuote(Quote quote);

        Task DeleteQuote(Guid id);

    }
}