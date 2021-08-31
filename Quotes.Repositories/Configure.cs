using Microsoft.Extensions.DependencyInjection;

namespace Quotes.Repositories
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IQuotesRepository, QuotesRepository>();
        }
    }
}
