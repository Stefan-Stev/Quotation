using AutoMapper;
using QuotationsWebApi.Dtos;
using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationsWebApi.MappingConfiguration
{
    public class QuotationProfile:Profile
    {
        public QuotationProfile()
        {
            CreateMap<QuotationDto, Quotation>();
            CreateMap<Quotation, QuotationDto>();
        }
    }
}
