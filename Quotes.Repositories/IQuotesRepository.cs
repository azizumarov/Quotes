using Quotes.Models;
using System;
using System.Collections.Generic;

namespace Quotes.Repositories
{
    public interface IQuotesRepository
    {
        IEnumerable<Quote> GetQuotes();

        Quote GetQuote(Guid id);

        void DeleteQuote(Guid id);
    }
}