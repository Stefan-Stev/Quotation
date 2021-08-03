using Application.Commands;
using Application.Contracts.Dtos.DossierDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingConfiguration
{
    public class DossierProfile : Profile
    {
        public DossierProfile()
        {
            CreateMap<DossierUpdateCommand, Dossier>();
            CreateMap<DossierGetDto, Dossier>();
            CreateMap<Dossier, DossierGetDto>();
            CreateMap<DossierCreateCommand, Dossier>();
        }
    }
}
