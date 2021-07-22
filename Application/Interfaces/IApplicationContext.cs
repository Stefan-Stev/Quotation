using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Dossier> Dossiers { get; set; }
        DbSet<Quotation> Quotations { get; set; }
        Task<int> SaveChangesAsync();
    }
}
