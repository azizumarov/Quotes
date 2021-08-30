using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quotes.Core;
using Quotes.Models;
using Quotes.Rest.Dtos.Quotes;
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
        [SwaggerOperation(
            Summary = "Get quotes by filter or random one - Summary",
            Description = "Get quotes by filter or random one - Description",
            OperationId = "GetQuotes",
            Tags = new[] { "Quotes" }
        )]
        public ActionResult<IEnumerable<QuoteDto>> GetQuotes(
            [FromQuery] [SwaggerParameter(Description = "The number of elemets to skip", Required = false)] int? skip, 
            [FromQuery] [SwaggerParameter(Description = "The number of elemets to take", Required = false)] int? take,
            [FromQuery] [SwaggerParameter(Description = "Filter quote author", Required = false)] string author, 
            [FromQuery] [SwaggerParameter(Description = "Filter quote category", Required = false)] string category,
            [FromQuery] [SwaggerParameter(Description = "Get Random quote from filtered quotes", Required = true)] bool random = false)
        {
            var quotes = this.service.GetQuotes(skip, take, author, category).Select(quote=> quote.AsDto());

            if (random)
            {
                quotes = new List<QuoteDto>(){ quotes.ElementAt(new Random().Next(quotes.Count())) };
            } 
            if (quotes is null)
            {
                return NoContent();
            }

            return Ok(quotes);
            
        }

        
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a quote by id - Summary",
            Description = "Get a quote by id - Description",
            OperationId = "GetQuote",
            Tags = new[] { "Quotes" }
        )]
        public ActionResult<QuoteDto> GetQuote([SwaggerParameter(Description = "Requested quote ID", Required = true)]  Guid id)
        {
            var quote = this.service.GetQuote(id).AsDto();

            if (quote is null)
            {
                return NotFound();
            }

            return Ok(quote);

        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a quote - Summary",
            Description = "Create a quote - Description",
            OperationId = "CreateQuote",
            Tags = new[] { "Quotes" }
        )]
        public ActionResult<QuoteDto> CreateQuote([FromBody] CreateQuoteDto quote)
        {
            try
            {
                var newQuote = this.service.CreateQuote(quote.Author, quote.Quote, quote.Category);

                return CreatedAtAction(nameof(GetQuote), new { Id = newQuote.Id }, newQuote.AsDto());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a quote by id - Summary",
            Description = "Update a quote by id - Description",
            OperationId = "UpdateQuote",
            Tags = new[] { "Quotes" }
        )]
        public ActionResult UpdateQuote([SwaggerParameter(Description = "Requested quote ID", Required = true)] Guid id, [FromBody] UpdateQuoteDto quote)
        {
            try
            {
                var quoteOld = this.service.GetQuote(id);
                quoteOld.Category = quote.Category;
                quoteOld.Value = quote.Quote;
                this.service.UpdateQuote(quoteOld);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a quote by id - Summary",
            Description = "Get a quote by id - Description",
            OperationId = "DeleteQuote",
            Tags = new[] { "Quotes" }
        )]
        public ActionResult DeleteQuote([SwaggerParameter(Description = "Requested quote ID", Required = true)] Guid id)
        {
            try
            {
                this.service.DeleteQuote(id);
                return NoContent();
            } catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
