using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quotes.Models;
using Quotes.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Rest.Controllers
{
    [ApiController]
    [Route("quotes")]
    public class QuotesController : ControllerBase
    {


        private readonly ILogger<QuotesController> logger;

        private QuotesRepository repository;

        public QuotesController(ILogger<QuotesController> logger)
        {
            this.logger = logger;
            this.repository = new QuotesRepository();
        }

        
        [HttpGet]
        public IEnumerable<Quote> GetQuotes([FromQuery] int? skip, [FromQuery] int? take, [FromQuery] string author, [FromQuery] string category)
        {
            return this.repository.GetQuotes().Where(quote => 
                    quote.Author.Contains(author ?? string.Empty) 
                    && quote.Category.Contains(category ?? string.Empty))
                .Skip(skip ?? 0).Take(take ?? int.MaxValue);
        }

        
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get's a quote by id - Summary",
            Description = "Get's a quote by id - Description",
            OperationId = "GetQuote",
            Tags = new[] { "Quotes" }
        )]
        public Quote GetQuote([SwaggerParameter(Description = "Requested quote ID", Required = true)]  Guid id)
        {
            return this.repository.GetQuote(id);
        }

    }
}
