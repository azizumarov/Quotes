using Quotes.Models;
using System;
using System.Collections.Generic;

namespace Quotes.Core
{
    public interface IQuotesService
    {

        IEnumerable<Quote> GetQuotes();

        Quote GetQuote(Guid id);
    }
}
