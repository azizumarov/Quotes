using Quotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quotes.Repositories
{
    public class QuotesRepository
    {
        private readonly IList<Quote> list = new List<Quote>()
        {
            new Quote(){ Id = Guid.NewGuid(), Author="Author 1", Value="some quote 1", Category = "Category 1", CreateOn = DateTime.Now, Deleted = false },
            new Quote(){ Id = Guid.NewGuid(), Author="Author 2", Value="some quote 2", Category = "Category 2", CreateOn = DateTime.Now, Deleted = false },
            new Quote(){ Id = Guid.NewGuid(), Author="Author 3", Value="some quote 3", Category = "Category 3", CreateOn = DateTime.Now, Deleted = false }
        };

        public IEnumerable<Quote> GetQuotes()
        {
            return list.Where(quote => !quote.Deleted);
        }

        public Quote GetQuote(Guid id)
        {
            return list.Where(quote => !quote.Deleted && quote.Id == id).FirstOrDefault();
        }
    }
}
