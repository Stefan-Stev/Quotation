using Application.Contracts.Dtos.DossierDtos;
using Application.Features.DossierFeatures.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingConfiguration
{
    public class DossierProfile : Profile
    {
        public DossierProfile()
        {
            CreateMap<DossierForCreationUpdateDto, Dossier>();
            CreateMap<Dossier, DossierForCreationUpdateDto>();
            CreateMap<DossierUpdateCommand, Dossier>();
            CreateMap<DossierGetDto, Dossier>();
            CreateMap<Dossier, DossierGetDto>();
            CreateMap<DossierCreateCommand, Dossier>();
        }
    }
}
