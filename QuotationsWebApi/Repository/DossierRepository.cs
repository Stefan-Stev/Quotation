using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using QuotationsWebApi.Context;
using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationsWebApi.Repository
{
    public class DossierRepository : IDossierRepository
    {
        private readonly QuotationContext _quotationContext;

        public DossierRepository(QuotationContext quotationContext)
        {
            _quotationContext = quotationContext;
        }

        public async Task<Dossier> GetDossierById(Guid id)
        {
            var dossier = await _quotationContext.Dossiers.Include(dossier => dossier.Quotations)
                                                          .FirstOrDefaultAsync(dossier => dossier.Id == id);

            if (dossier != null)
            {
                return dossier;
            }

            throw new Exception("Dossier not found");
        }

        public async Task<List<Dossier>> GetAllDossier()
        {
            return await _quotationContext.Dossiers.Include(dossier => dossier.Quotations).ToListAsync();
        }

        public async Task DeleteDossier(Guid id)
        {
            var dossier = await _quotationContext.Dossiers.FindAsync(id);
            if (dossier == null)
                throw new Exception("No dossier was found to be deleted!");
            _quotationContext.Remove(dossier);
            await _quotationContext.SaveChangesAsync();
        }

        public async Task Update(Dossier dossier)
        {
            _quotationContext.Entry(dossier).State = EntityState.Modified;
            await _quotationContext.SaveChangesAsync();
        }

        public async Task<Dossier> Patch(Guid id, JsonPatchDocument<Dossier> dossier)
        {
            var dossierToUpdate = await _quotationContext.Dossiers.FindAsync(id);
            if (dossierToUpdate == null)
                throw new Exception("No dossier was found");

            dossier.ApplyTo(dossierToUpdate);
            await _quotationContext.SaveChangesAsync();
            return dossierToUpdate;
        }

        public async Task CreateDossier(Dossier dossier)
        {
            var dossierToCreate = await _quotationContext.Dossiers.FindAsync(dossier.Id);
            if (dossierToCreate == null)
            {
                await _quotationContext.Dossiers.AddAsync(dossier);
                await _quotationContext.SaveChangesAsync();
            }
            else
                throw new Exception("This dossier already exists!");
        }

        public bool DossierExists(Guid id) => _quotationContext.Dossiers.Any(d => d.Id==id);



    }
}
