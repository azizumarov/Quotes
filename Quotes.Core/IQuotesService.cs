using Quotes.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.Core
{
    public interface IQuotesService
    {

        Task<IEnumerable<Quote>> GetQuotes(int? skip, int? take, string author, string category);

        Task<Quote> GetQuote(Guid id);

        Task<Quote> CreateQuote(string author, string quote, string category);

        Task UpdateQuote(Quote quote);

        Task DeleteQuote(Guid id);

    }
}
