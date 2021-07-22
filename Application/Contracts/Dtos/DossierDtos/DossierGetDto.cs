using Application.Contracts.Dtos.QuotationDtos;
using System;
using System.Collections.Generic;

namespace Application.Contracts.Dtos.DossierDtos
{
    public class DossierGetDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public ICollection<QuotationGetDto> Quotations { get; set; } = new HashSet<QuotationGetDto>();
    }
}
