using Quotes.Models;
using Quotes.Repositories;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Quote> GetQuotes()
        {
            return this.repository.GetQuotes();
        }
    }
}
