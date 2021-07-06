using QuotationsWebApi.Context;
using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotationsWebApi.Repository
{
    public class QuotationRepository : IQuotationRepository
    {
  
        public QuotationRepository()
        {
            if (QuotationContext.quotationList == null)
                QuotationContext.quotationList = new List<Quotation>();
        }
        public List<Quotation> GetAll()
        {
            return QuotationContext.quotationList;
        }
        public Quotation GetById(Guid id)
        {
            var quotation= QuotationContext.quotationList.Where(s => s.Id == id).ElementAtOrDefault(0);
            if (quotation!=null)
                return quotation;
            else
                throw new Exception("There is now quotation like this one !");

        }
        public void Delete(Guid id)
        {
            try
            {
                var quatation = QuotationContext.quotationList.Single(q => q.Id == id);

                QuotationContext.quotationList.Remove(quatation);
            }
            catch (Exception ex)
            {
                throw new Exception($"There is now quotation like this one!!!:{ex.Message}");

            }

        }
        public void Update(Quotation quatation)
        {
            var quatationToUpdate = QuotationContext.quotationList.Where(s => s.Id == quatation.Id).ElementAtOrDefault(0);
            quatationToUpdate.DataCreated = quatation.DataCreated;
            quatationToUpdate.DataUntilValid = quatation.DataUntilValid;
            quatationToUpdate.Price = quatation.Price;
            quatationToUpdate.Status = quatation.Status;
            quatationToUpdate.DossierId = quatation.DossierId;
        }
        public void Create(Quotation quatation)
        {
            QuotationContext.quotationList.Add(quatation);
            
        }



    }
}
