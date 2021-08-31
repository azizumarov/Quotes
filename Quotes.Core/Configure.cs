using Microsoft.Extensions.DependencyInjection;

namespace Quotes.Core
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IQuotesService, QuotesService>();
            services.AddHostedService<QuoteDeleteService>();
        }
    }
}
