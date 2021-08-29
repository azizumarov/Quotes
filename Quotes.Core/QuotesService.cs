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
        
        public void CreateQuote(Quote quote)
        {
            this.repository.CreateQuote(quote);
        }

        public void UpdateQuote(Guid id, Quote quote)
        {
            this.repository.UpdateQuote(id, quote);
        }
        
        public void DeleteQuote(Guid id)
        {
            this.repository.DeleteQuote(id);
        }

    }
}
