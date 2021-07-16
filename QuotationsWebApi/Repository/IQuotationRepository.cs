using Microsoft.AspNetCore.JsonPatch;
using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuotationsWebApi.Repository
{
    public interface IQuotationRepository
    {
        Task CreateQuotation(Quotation quotation);
        Task DeleteQuotation (Guid id);
        Task<List<Quotation>> GetAllQuotations();
        Task<Quotation> GetQuotationById(Guid id);
        Task<Quotation> Patch(Guid id, JsonPatchDocument<Quotation> quotation);
        Task Update(Quotation quotation);
        Task AddQuotationToDossier(Quotation quotation, Dossier dossier);
        bool QuotationExists(Guid Id);
    }
}