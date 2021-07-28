using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence
{
    public static class PersistenceDI
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuotationContext>(options =>  options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(QuotationContext).Assembly.FullName)));
            services.AddScoped<IApplicationContext>(provider => provider.GetService<QuotationContext>());
        }
    }
}
