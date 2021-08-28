using Quotes.Models;
using System;
using System.Collections.Generic;

namespace Quotes.Core
{
    public interface IQuotesService
    {

        IEnumerable<Quote> GetQuotes(int? skip, int? take, string author, string category);

        Quote GetQuote(Guid id);

        void DeleteQuote(Guid id);
    }
}
