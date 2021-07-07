

using QuotationsWebApi.Entities;
using System.Collections.Generic;

namespace QuotationsWebApi.Context
{
    public class QuotationContext:IQuotationContext
    {
        public  List<Quotation> quotationList { get; set; }
        public QuotationContext()
        {
            quotationList = new List<Quotation>();
        }
        
    }
}
