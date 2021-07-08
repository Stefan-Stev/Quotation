using Microsoft.AspNetCore.JsonPatch;
using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;

namespace QuotationsWebApi.Repository
{
    public interface IQuotationRepository
    {
        void Create(Quotation quotation);
        void Delete(Guid id);
        List<Quotation> GetAll();
        Quotation GetById(Guid id);
        Quotation Patch(Guid id, JsonPatchDocument<Quotation> quotation);
        void Update(Quotation quotation);
        public bool QuotationExists(Guid Id);
    }
}