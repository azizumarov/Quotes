using Quotes.Models;
using Quotes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Core
{
    public class QuotesService : IQuotesService
    {
        private readonly IQuotesRepository _repository;

        public QuotesService(IQuotesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Quote> GetQuoteAsync(Guid id)
        {
            return await _repository.GetQuoteAsync(id);
        }

        public async Task<IEnumerable<Quote>> GetQuotesAsync(int? skip, int? take, string author, string category)
        {
            return (await _repository.GetQuotesAsync()).Where(quote =>
                    quote.Author.Contains(author ?? string.Empty)
                    && quote.Category.Contains(category ?? string.Empty))
                .Skip(skip ?? 0).Take(take ?? int.MaxValue).ToList();
        }

        public async Task<Quote> CreateQuoteAsync(string author, string quote, string category)
        {
            return await _repository.CreateQuoteAsync(author, quote, category);
        }

        public async Task UpdateQuoteAsync(Quote quote)
        {
            await _repository.UpdateQuoteAsync(quote);
        }

        public async Task DeleteQuoteAsync(Guid id)
        {
            await _repository.DeleteQuoteAsync(id);
        }
    }
}