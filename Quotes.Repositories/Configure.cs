using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
