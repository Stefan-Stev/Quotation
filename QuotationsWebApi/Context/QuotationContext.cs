

using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;

namespace QuotationsWebApi.Context
{
    public class QuotationContext
    {
        public static List<Quotation> quotationList { get; set; }
        /*public QuatationContext()
        {
            var quotation1 = new Quatation
            {
                Id = Guid.Parse("8693e167-c32c-437f-a851-90ba6c5a47bc"),
                Name = "Quatation1",
                DossierId = Guid.Parse("16243c8c-bb79-4264-b4f8-72a5234af725"),
                Price = 12.5f,
                Status = Status.Approved,
                DataCreated = DateTime.Now,
                DataUntilValid = DateTime.Today.AddDays(1)
            };
            var quotation2 = new Quatation
            {
                Id = Guid.Parse("8693e167-c32c-437f-a851-90ba6c5a47bd"),
                Name = "Quatation1",
                DossierId = Guid.Parse("16243c8c-bb79-4264-b4f8-72a5234af726"),
                Price = 13.5f,
                Status = Status.UnderEvaluation,
                DataCreated = DateTime.Now,
                DataUntilValid = DateTime.Today.AddDays(2)
            };
            this.quatationList = new List<Quatation>();
            quatationList.Add(quotation1);
            quatationList.Add(quotation2);
        }*/
    }
}
