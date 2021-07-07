using Microsoft.AspNetCore.JsonPatch;
using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;

namespace QuotationsWebApi.Repository
{
    public interface IQuotationRepository
    {
        void Create(Quotation quatation);
        void Delete(Guid id);
        List<Quotation> GetAll();
        Quotation GetById(Guid id);
        Quotation Update(Guid id, JsonPatchDocument<Quotation> quatation);
    }
}