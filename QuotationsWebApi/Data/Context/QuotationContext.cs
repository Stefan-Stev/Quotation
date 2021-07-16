
using Microsoft.EntityFrameworkCore;
using QuotationsWebApi.Entities;

namespace QuotationsWebApi.Context
{
    public class QuotationContext: DbContext
    {
        public QuotationContext(DbContextOptions<QuotationContext>options):base(options)
        {

        }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.CurrentDossier)
                .WithMany(d => d.Quotations)
                .HasForeignKey(q => q.DossierId);
        }
    }
}
