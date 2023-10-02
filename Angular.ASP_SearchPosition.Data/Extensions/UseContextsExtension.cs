using Angular.ASP_SearchPosition.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.ASP_SearchPosition.Data.Extensions
{
    public static class UseContextsExtension
    {
        public static IServiceCollection AddDataContexts(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SearchDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
