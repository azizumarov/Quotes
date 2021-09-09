using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Quotes.Core
{
    public class QuoteDeleteService : IHostedService, IDisposable
    {
        private readonly ILogger<QuoteDeleteService> _logger;
        private readonly IQuotesService _quotesService;
        private Timer _timer;

        public QuoteDeleteService(IQuotesService quotesService, ILogger<QuoteDeleteService> logger)
        {
            _logger = logger;
            _quotesService = quotesService;
        }

        void IDisposable.Dispose()
        {
            _timer?.Dispose();
        }


        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            _logger.LogInformation("Timed Hosted Service is working");
            var quotes = (await _quotesService.GetQuotesAsync(null, null, string.Empty, string.Empty))
                .Where(quote => quote.CreateOn < DateTime.Now.AddDays(-1));
            foreach (var quote in quotes) await _quotesService.DeleteQuoteAsync(quote.Id);
        }
    }
}