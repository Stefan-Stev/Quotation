

using Microsoft.EntityFrameworkCore;
using QuotationsWebApi.Entities;
using System.Collections.Generic;

namespace QuotationsWebApi.Context
{
    public class QuotationContext: DbContext
    {
        public QuotationContext(DbContextOptions<QuotationContext>options):base(options)
        {

        }
        public DbSet<Quotation> Quotations { get; set; }

        
    }
}
