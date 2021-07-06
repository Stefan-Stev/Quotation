using QuotationsWebApi.Entities;
using System.Collections.Generic;

namespace QuotationsWebApi.Context
{
    public interface IQuotationContext
    {
        List<Quotation> quotationList { get; set; }
    }
}