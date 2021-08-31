using Quotes.Models;
using Quotes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Core.Test.Mocks
{
    internal class QuotesRepositoryMock : IQuotesRepository
    {
        private readonly IList<Quote> _list = new List<Quote>()
        {
            new Quote()
            {
                Id = Guid.NewGuid(), Author = "Author 1", Value = "some quote 1", Category = "Category 1",
                CreateOn = DateTime.Now, Deleted = false
            },
            new Quote()
            {
                Id = Guid.NewGuid(), Author = "Author 2", Value = "some quote 2", Category = "Category 2",
                CreateOn = DateTime.Now, Deleted = false
            },
            new Quote()
            {
                Id = Guid.NewGuid(), Author = "Author 3", Value = "some quote 3", Category = "Category 3",
                CreateOn = DateTime.Now.AddDays(-2), Deleted = false
            }
        };

        public async Task<IEnumerable<Quote>> GetQuotesAsync()
        {
            var quotes = _list.Where(quote => !quote.Deleted);
            return await Task.FromResult(quotes);
        }

        public async Task<Quote> GetQuoteAsync(Guid id)
        {
            var quote = _list.FirstOrDefault(quote => !quote.Deleted && quote.Id == id);

            if (quote != null)
            {
                return await Task.FromResult(quote);
            }

            throw new Exception("Quote not found");
        }

        public async Task<Quote> CreateQuoteAsync(string author, string value, string category)
        {
            var newQuote = new Quote
            { Id = Guid.NewGuid(), Author = author, Value = value, Category = category, CreateOn = DateTime.Now };
            _list.Add(newQuote);
            return await Task.FromResult(newQuote);
        }

        public async Task UpdateQuoteAsync(Quote quote)
        {
            var quoteOld = _list.FirstOrDefault(q => !q.Deleted && quote.Id == q.Id);

            if (quoteOld != null)
            {
                quoteOld.Author = quote.Author;
                quoteOld.Category = quote.Category;
                quoteOld.Value = quote.Value;
                quoteOld.Modified = true;
                quoteOld.ModifiedOn = DateTime.Now;
            }
            else
            {
                throw new Exception("Quote not found");
            }

            await Task.CompletedTask;
        }

        public async Task DeleteQuoteAsync(Guid id)
        {
            var quote = _list.FirstOrDefault(quote => !quote.Deleted && quote.Id == id);

            if (quote != null)
            {
                quote.Deleted = true;
                quote.DeletedOn = DateTime.Now;
            }
            else
            {
                throw new Exception("Quote not found");
            }

            await Task.CompletedTask;
        }
    }
}
