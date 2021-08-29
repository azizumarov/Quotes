using Quotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quotes.Repositories
{
    public class QuotesRepository:IQuotesRepository
    {
        private readonly IList<Quote> list = new List<Quote>()
        {
            new Quote(){ Id = Guid.NewGuid(), Author="Author 1", Value="some quote 1", Category = "Category 1", CreateOn = DateTime.Now, Deleted = false },
            new Quote(){ Id = Guid.NewGuid(), Author="Author 2", Value="some quote 2", Category = "Category 2", CreateOn = DateTime.Now, Deleted = false },
            new Quote(){ Id = Guid.NewGuid(), Author="Author 3", Value="some quote 3", Category = "Category 3", CreateOn = DateTime.Now, Deleted = false }
        };

        public IEnumerable<Quote> GetQuotes()
        {
            var quotes = list.Where(quote => !quote.Deleted);
            if (quotes != null)
            {
                return quotes;
            }

            throw new Exception("Quotes not found");
        }

        public Quote GetQuote(Guid id)
        {
            var quote = list.Where(quote => !quote.Deleted && quote.Id == id).FirstOrDefault();

            if (quote != null)
            {
                return quote; 
            }
                
            throw new Exception("Quote not found");
        }

        public void CreateQuote(Quote quote)
        {
            list.Add(quote);
        }

        public void UpdateQuote(Quote quote)
        {
            var quoteOld = list.Where(q => !q.Deleted && quote.Id == q.Id).FirstOrDefault();

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
        }

        public void DeleteQuote(Guid id)
        {
            var quote = list.Where(quote => !quote.Deleted && quote.Id == id).FirstOrDefault();

            if (quote != null)
            {
                quote.Deleted = true;
                quote.DeletedOn = DateTime.Now;
            }
            else
            {
                throw new Exception("Quote not found");
            }
        }
    }
}
