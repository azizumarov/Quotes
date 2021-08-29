using Quotes.Models;
using System;
using System.Collections.Generic;

namespace Quotes.Repositories
{
    public interface IQuotesRepository
    {
        IEnumerable<Quote> GetQuotes();

        Quote GetQuote(Guid id);

        void CreateQuote(Quote quote);

        void UpdateQuote(Guid id, Quote quote);

        void DeleteQuote(Guid id);

    }
}