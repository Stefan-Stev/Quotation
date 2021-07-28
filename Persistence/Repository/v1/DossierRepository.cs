using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using QuotationsWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repository.v1
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
            return dossier;
        }

        public async Task<List<Dossier>> GetAllDossier()
        {
            return await _quotationContext.Dossiers.Include(dossier => dossier.Quotations).ToListAsync();
        }

        public async Task DeleteDossier(Dossier dossier)
        {
            _quotationContext.Remove(dossier);
            await _quotationContext.SaveChangesAsync();
        }

        public async Task<Dossier> Update(Dossier dossierUpdated)
        {
            if (dossierUpdated == null)
            {
                throw new ArgumentNullException("Quotation must not be null");
            }
            try
            {
                var localDossier = _quotationContext.Dossiers.FirstOrDefault(d => d.Id == dossierUpdated.Id);
                _quotationContext.Entry(localDossier).State = EntityState.Detached;
                _quotationContext.Entry(dossierUpdated).State = EntityState.Modified;
                await _quotationContext.SaveChangesAsync();
                return dossierUpdated;
            }
            catch (Exception e)
            {
                throw new Exception($"Quotation could not be updated: {e.Message}");
            }
        
        }

        public async Task  CreateDossier(Dossier dossier)
        {
            await _quotationContext.Dossiers.AddAsync(dossier);
            await _quotationContext.SaveChangesAsync();
        }

        public bool DossierExists(Guid id) => _quotationContext.Dossiers.Any(d => d.Id == id);

        
    }
}
