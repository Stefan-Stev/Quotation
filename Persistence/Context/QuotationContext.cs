
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class QuotationContext : DbContext, IApplicationContext
    {
        public QuotationContext(DbContextOptions<QuotationContext> options) : base(options)
        {

        }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.CurrentDossier)
                .WithMany(d => d.Quotations)
                .HasForeignKey(q => q.DossierId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("DataSource=quotation.db");
    }
}
