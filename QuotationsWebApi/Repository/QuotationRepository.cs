using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using QuotationsWebApi.Context;
using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotationsWebApi.Repository
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly QuotationContext quotationContext;

        public QuotationRepository(QuotationContext quotationContext)
        {
            this.quotationContext = quotationContext;
        }
        public List<Quotation> GetAll()
        {
            return quotationContext.Quotations.ToList();
        }
        public Quotation GetById(Guid id)
        {
            var quotation = quotationContext.Quotations.Find(id);
            if (quotation != null)
                return quotation;
            else
                throw new Exception("There is no quotation like this one !");

        }
        public void Delete(Guid id)
        {

            var quotation = quotationContext.Quotations.Find(id);
            if (quotation == null)
                throw new Exception("There is no quotation with this Id");
            quotationContext.Quotations.Remove(quotation);
            quotationContext.SaveChanges();


        }
        public Quotation Patch(Guid id, JsonPatchDocument<Quotation> quotation)
        {
            var quotationToUpdate = quotationContext.Quotations.Find(id);
            if (quotationToUpdate == null)
                throw new Exception("There is no quotation!");
            quotation.ApplyTo(quotationToUpdate);
            quotationContext.SaveChanges();
            return quotationToUpdate;

        }
        public void Update(Quotation quotation)
        {
            this.quotationContext.Entry(quotation).State = EntityState.Modified;
            quotationContext.SaveChanges();

        }
        public void Create(Quotation quotation)
        {
            var quotationToBeCreated = quotationContext.Quotations.Find(quotation.Id);
            if (quotationToBeCreated == null)
            {
                quotationContext.Quotations.Add(quotation);
                quotationContext.SaveChanges();
            }
            else
                throw new Exception("Quotation already exists!");



        }
        public bool QuotationExists(Guid Id) => quotationContext.Quotations.Any(e => e.Id == Id);



    }
}
