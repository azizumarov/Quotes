using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quotes.Core;
using Quotes.Models;

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

        private readonly IQuotesService service;

        public QuotesController(IQuotesService service, ILogger<QuotesController> logger)
        {
            this.logger = logger;
            this.service = service;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Quote>> GetQuotes([FromQuery] int? skip, [FromQuery] int? take, [FromQuery] string author, [FromQuery] string category)
        {
            var quiotes = this.service.GetQuotes().Where(quote =>
                    quote.Author.Contains(author ?? string.Empty)
                    && quote.Category.Contains(category ?? string.Empty))
                .Skip(skip ?? 0).Take(take ?? int.MaxValue);
            return Ok(quiotes);
        }

        
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get's a quote by id - Summary",
            Description = "Get's a quote by id - Description",
            OperationId = "GetQuote",
            Tags = new[] { "Quotes" }
        )]
        public ActionResult<Quote> GetQuote([SwaggerParameter(Description = "Requested quote ID", Required = true)]  Guid id)
        {
            var quote = this.service.GetQuote(id);

            if (quote is null)
            {
                return NotFound();
            }

            return quote;
        }

    }
}
