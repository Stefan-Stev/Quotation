using EnsureThat;
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

        public async  Task<Quotation> GetQuotationById(Guid id)
        {
            var quotation = await quotationContext.Quotations.FindAsync(id);
            if (quotation != null)
                return quotation;
            else
                throw new Exception("There is no quotation like this one !");
        }

        public async Task DeleteQuotation(Guid id)
        { 
            var quotation = await quotationContext.Quotations.FindAsync(id);
            if (quotation == null)
                throw new Exception("There is no quotation with this Id");
            quotationContext.Quotations.Remove(quotation);
            await quotationContext.SaveChangesAsync();
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

        public async Task Update(Quotation quotation)
        {
            this.quotationContext.Entry(quotation).State = EntityState.Modified;
            await quotationContext.SaveChangesAsync();
        }

        public async Task CreateQuotation(Quotation quotation)
        {
            Dossier dossier = await quotationContext.Dossiers.FindAsync(quotation.DossierId);
            EnsureArg.IsNotNull(dossier, nameof(dossier));
            var quotationToBeCreated = await quotationContext.Quotations.FindAsync(quotation.Id);
            if (quotationToBeCreated == null)
            {
                dossier.Quotations.Add(quotation);
                quotation.CurrentDossier = dossier;
                await quotationContext.Quotations.AddAsync(quotation);
                await quotationContext.SaveChangesAsync();
            }
            else
                throw new Exception("Quotation already exists!");
        }

        [ObsoleteAttribute("This method is obsolete. Patch() instead.", true)]
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
            await this.quotationContext.SaveChangesAsync();
        }

        public bool QuotationExists(Guid Id) => quotationContext.Quotations.Any(e => e.Id == Id);
    }
}
