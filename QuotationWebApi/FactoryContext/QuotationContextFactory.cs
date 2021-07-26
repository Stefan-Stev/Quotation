using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationWebApi.FactoryContext
{
    public class QuotationContextFactory : IDesignTimeDbContextFactory<QuotationContext>
    {
        public QuotationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuotationContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");

            return new QuotationContext(optionsBuilder.Options);
        }
    }
}
