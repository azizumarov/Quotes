using Quotes.Models;
using Quotes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotes.Core
{
    public class QuotesService : IQuotesService
    {
        private IQuotesRepository repository;
        
        public QuotesService(IQuotesRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Quote> GetQuote(Guid id)
        {
            return await this.repository.GetQuote(id);
        }

        public async Task<IEnumerable<Quote>> GetQuotes(int? skip, int? take, string author, string category)
        {
            return (await this.repository.GetQuotes()).Where(quote =>
                    quote.Author.Contains(author ?? string.Empty)
                    && quote.Category.Contains(category ?? string.Empty))
                .Skip(skip ?? 0).Take(take ?? int.MaxValue);
        }
        
        public async Task<Quote> CreateQuote(string author, string quote, string category)
        {
            return await this.repository.CreateQuote(author, quote, category);
        }

        public async Task UpdateQuote(Quote quote)
        {
            await this.repository.UpdateQuote(quote);
        }
        
        public async Task DeleteQuote(Guid id)
        {
            await this.repository.DeleteQuote(id);
        }

    }
}
