using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quotes.Core
{
    public class QuoteDeleteService : IHostedService, IDisposable
    {
        ILogger<QuoteDeleteService> logger;
        private Timer timer;
        IQuotesService quotesService;

        public QuoteDeleteService(IQuotesService quotesService, ILogger<QuoteDeleteService> logger)
        {
            this.logger = logger;
            this.quotesService = quotesService;
        }


        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Timed Hosted Service running.");

            this.timer = new Timer((_) => { _ = DoWorkAsync(); }, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        private async Task DoWorkAsync()
        {
            this.logger.LogInformation("Timed Hosted Service is working");
            var quotes = (await this.quotesService.GetQuotesAsync(null, null, string.Empty, string.Empty))
                .Where(quote => quote.CreateOn < DateTime.Now.AddDays(-1));
            foreach(var quote in quotes)
            {
                await this.quotesService.DeleteQuoteAsync(quote.Id);
            }

        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Timed Hosted Service is stopping.");

            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        void IDisposable.Dispose()
        {
            this.timer?.Dispose();
        }
    }
}
