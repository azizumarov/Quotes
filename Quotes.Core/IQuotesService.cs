using Quotes.Models;
using System;
using System.Collections.Generic;

namespace Quotes.Core
{
    public interface IQuotesService
    {

        IEnumerable<Quote> GetQuotes(int? skip, int? take, string author, string category);

        Quote GetQuote(Guid id);

        Quote CreateQuote(string author, string quote, string category);

        void UpdateQuote(Quote quote);

        void DeleteQuote(Guid id);

    }
}
