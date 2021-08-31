using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quotes.Core;
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
        public async Task<ActionResult<IEnumerable<QuoteDto>>> GetQuotesAsync(
            [FromQuery][SwaggerParameter(Description = "The number of elemets to skip", Required = false)] int? skip,
            [FromQuery][SwaggerParameter(Description = "The number of elemets to take", Required = false)] int? take,
            [FromQuery][SwaggerParameter(Description = "Filter quote author", Required = false)] string author,
            [FromQuery][SwaggerParameter(Description = "Filter quote category", Required = false)] string category,
            [FromQuery][SwaggerParameter(Description = "Get Random quote from filtered quotes", Required = true)] bool random = false)
        {
            var quotes = (await this.service.GetQuotesAsync(skip, take, author, category)).Select(quote => quote.AsDto());

            if (random)
            {
                quotes = new List<QuoteDto>() { quotes.ElementAt(new Random().Next(quotes.Count())) };
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
        public async Task<ActionResult<QuoteDto>> GetQuoteAsync([SwaggerParameter(Description = "Requested quote ID", Required = true)] Guid id)
        {
            var quote = (await this.service.GetQuoteAsync(id)).AsDto();

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
        public async Task<ActionResult<QuoteDto>> CreateQuoteAsync([FromBody] CreateQuoteDto quote)
        {
            try
            {
                var newQuote = await this.service.CreateQuoteAsync(quote.Author, quote.Quote, quote.Category);

                return CreatedAtAction(nameof(GetQuoteAsync), new { newQuote.Id }, newQuote.AsDto());
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
        public async Task<ActionResult> UpdateQuoteAsync([SwaggerParameter(Description = "Requested quote ID", Required = true)] Guid id, [FromBody] UpdateQuoteDto quote)
        {
            try
            {
                var quoteOld = await this.service.GetQuoteAsync(id);
                quoteOld.Category = quote.Category;
                quoteOld.Value = quote.Quote;
                await this.service.UpdateQuoteAsync(quoteOld);
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
        public async Task<ActionResult> DeleteQuoteAsync([SwaggerParameter(Description = "Requested quote ID", Required = true)] Guid id)
        {
            try
            {
                await this.service.DeleteQuoteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
