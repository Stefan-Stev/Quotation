using Microsoft.AspNetCore.JsonPatch;
using QuotationsWebApi.Context;
using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotationsWebApi.Repository
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly IQuotationContext quotationContext;

        public QuotationRepository(IQuotationContext quotationContext)
        { 
            this.quotationContext = quotationContext;
        }
        public List<Quotation> GetAll()
        {
            return quotationContext.quotationList;
        }
        public Quotation GetById(Guid id)
        {
            var quotation= quotationContext.quotationList.FirstOrDefault(s => s.Id == id);
            if (quotation!=null)
                return quotation;
            else
                throw new Exception("There is no quotation like this one !");

        }
        public void Delete(Guid id)
        {
            
            var quotation = quotationContext.quotationList.FirstOrDefault(q => q.Id == id);
            if (quotation == null)
                throw new Exception("There is no quotation with this Id");
            quotationContext.quotationList.Remove(quotation);
            

        }
        public Quotation Update(Guid id,JsonPatchDocument<Quotation> quotation)
        {
            var quotationToUpdate = quotationContext.quotationList.FirstOrDefault(s => s.Id ==id);
            if (quotationToUpdate == null)
                throw new Exception("There is no quotation!");
            quotation.ApplyTo(quotationToUpdate);
            return quotationToUpdate;
            
        }
        public void Create(Quotation quotation)
        {
            var quotationToBeCreated = quotationContext.quotationList.FirstOrDefault(s => s.Id == quotation.Id);
            if (quotationToBeCreated==null)
            {
                quotationContext.quotationList.Add(quotation);

            }
            else
                throw new Exception("Quotation already exists!");
            
            
            
        }



    }
}
