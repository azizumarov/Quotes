using Quotes.Models;
using System;
using System.Collections.Generic;

namespace Quotes.Repositories
{
    public interface IQuotesRepository
    {
        IEnumerable<Quote> GetQuotes();

        Quote GetQuote(Guid id);

        Quote CreateQuote(string author, string value, string category);

        void UpdateQuote(Quote quote);

        void DeleteQuote(Guid id);

    }
}