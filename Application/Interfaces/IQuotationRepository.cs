using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuotationsWebApi.Repository
{
    public interface IQuotationRepository
    {
        Task CreateQuotation(Quotation quotation);
        Task<Quotation> DeleteQuotation (Quotation quotation);
        Task<List<Quotation>> GetAllQuotations();
        Task<Quotation> GetQuotationById(Guid id);
        Task<Quotation> Patch(Guid id, JsonPatchDocument<Quotation> quotation);
        Task<Quotation> Update(Quotation quotation);
        Task AddQuotationToDossier(Quotation quotation, Dossier dossier);
        bool QuotationExists(Guid Id);

        Task SaveChangeAsync();
    }
}