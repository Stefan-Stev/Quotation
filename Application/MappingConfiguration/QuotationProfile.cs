using Application.Commands;
using Application.Contracts.Dtos.QuotationDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingConfiguration
{
    public class QuotationProfile : Profile
    {
        public QuotationProfile()
        {
            CreateMap<QuotationCreateCommand, Quotation>();
            CreateMap<Quotation, QuotationCreateCommand>();
            CreateMap<QuotationUpdateCommand, Quotation>();
            CreateMap<Quotation, QuotationUpdateCommand>();
            CreateMap<QuotationGetDto, Quotation>();
            CreateMap<Quotation, QuotationGetDto>();
        }
    }
}
