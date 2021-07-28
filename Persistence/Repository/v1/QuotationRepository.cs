using Domain.Entities;
using EnsureThat;
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
    public class QuotationRepository : IQuotationRepository
    {
        private readonly QuotationContext quotationContext;

        public QuotationRepository(QuotationContext quotationContext)
        {
            this.quotationContext = quotationContext;
        }

        public async Task<List<Quotation>> GetAllQuotations()
        {
            return await quotationContext.Quotations.ToListAsync();
        }

        public async Task<Quotation> GetQuotationById(Guid id)
        {
            var quotation = await quotationContext.Quotations.FindAsync(id);
            return quotation;
        }

        public async Task<Quotation> DeleteQuotation(Quotation quotation)
        {
            try
            {
                quotationContext.Quotations.Remove(quotation);
                await quotationContext.SaveChangesAsync();
                return quotation;
            }
            catch (Exception e)
            {
                throw new Exception($"Quotation could not be deleted: {e.Message}");
            }
                
            
        }

        public async Task<Quotation> Patch(Guid id, JsonPatchDocument<Quotation> quotation)
        {
            var quotationToUpdate = await quotationContext.Quotations.FindAsync(id);
            if (quotationToUpdate == null)
                throw new Exception("There is no quotation!");
            quotation.ApplyTo(quotationToUpdate);
            await quotationContext.SaveChangesAsync();
            return quotationToUpdate;
        }

        public async Task<Quotation> Update(Quotation quotationUpdated)
        {
            if (quotationUpdated == null)
            {
                throw new ArgumentNullException("Quotation must not be null");
            }
            try
            {
                var local = quotationContext.Set<Quotation>().Local
                                                             .FirstOrDefault(entry => entry.Id.Equals(quotationUpdated.Id));
                quotationContext.Entry(local).State = EntityState.Detached;
                quotationContext.Entry(quotationUpdated).State = EntityState.Modified;
                await quotationContext.SaveChangesAsync();
                return quotationUpdated;
            }
            catch (Exception e)
            {
                throw new Exception($"Quotation could not be updated: {e.Message}");
            }
        }
        public async Task SaveChangeAsync()
        {
            await quotationContext.SaveChangesAsync();
        }

        public async Task CreateQuotation(Quotation quotation)
        {
            Dossier dossier = await quotationContext.Dossiers.FindAsync(quotation.DossierId);
            EnsureArg.IsNotNull(dossier, nameof(dossier));
            dossier.Quotations.Add(quotation);
            quotation.CurrentDossier = dossier;
            await quotationContext.Quotations.AddAsync(quotation);
            await quotationContext.SaveChangesAsync();
        }
        

        [Obsolete("This method is obsolete. Patch() instead.", true)]
        public async Task AddQuotationToDossier(Quotation quotation, Dossier dossier)
        {
            var quotationToBeAdded = await quotationContext.Quotations.FindAsync(quotation.Id);
            var dossierOfQuotation = await quotationContext.Dossiers.FindAsync(dossier.Id);
            if (dossierOfQuotation == null)
            {
                throw new Exception("Dossier does not exist!");
            }
            if (quotationToBeAdded == null)
            {
                throw new Exception("Quotation does not exist!");
            }
            dossierOfQuotation.Quotations.Add(quotationToBeAdded);
            await quotationContext.SaveChangesAsync();
        }

        public bool QuotationExists(Guid Id) => quotationContext.Quotations.Any(e => e.Id == Id);

    }
}
