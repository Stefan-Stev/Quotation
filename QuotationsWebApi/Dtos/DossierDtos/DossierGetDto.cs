using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationsWebApi.Dtos
{
    public class DossierGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<QuotationGetDto> Quotations { get; set; } = new HashSet<QuotationGetDto>();
    }
}
