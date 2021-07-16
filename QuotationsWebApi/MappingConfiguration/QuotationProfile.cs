using AutoMapper;
using QuotationsWebApi.Dtos;
using QuotationsWebApi.Entities;

namespace QuotationsWebApi.MappingConfiguration
{
    public class QuotationProfile:Profile
    {
        public QuotationProfile()
        {
            CreateMap<QuotationForCreationDto, Quotation>();
            CreateMap<Quotation, QuotationForCreationDto>();
            CreateMap<QuotationGetDto, Quotation>();
            CreateMap<Quotation, QuotationGetDto>();
        }
    }
}
