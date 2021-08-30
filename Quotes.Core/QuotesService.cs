using Quotes.Models;
using Quotes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quotes.Core
{
    public class QuotesService : IQuotesService
    {
        private IQuotesRepository repository;
        
        public QuotesService(IQuotesRepository repository)
        {
            this.repository = repository;
        }
        public Quote GetQuote(Guid id)
        {
            return this.repository.GetQuote(id);
        }

        public IEnumerable<Quote> GetQuotes(int? skip, int? take, string author, string category)
        {
            return this.repository.GetQuotes().Where(quote =>
                    quote.Author.Contains(author ?? string.Empty)
                    && quote.Category.Contains(category ?? string.Empty))
                .Skip(skip ?? 0).Take(take ?? int.MaxValue);
        }
        
        public Quote CreateQuote(string author, string quote, string category)
        {
            return this.repository.CreateQuote(author, quote, category);
        }

        public void UpdateQuote(Quote quote)
        {
            this.repository.UpdateQuote(quote);
        }
        
        public void DeleteQuote(Guid id)
        {
            this.repository.DeleteQuote(id);
        }

    }
}
