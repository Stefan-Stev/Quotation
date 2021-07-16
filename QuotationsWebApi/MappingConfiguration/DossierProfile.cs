using AutoMapper;
using QuotationsWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotationsWebApi.Entities;

namespace QuotationsWebApi.MappingConfiguration
{
    public class DossierProfile:Profile
    {
        public DossierProfile()
        {
            CreateMap<DossierForCreationUpdateDto, Dossier>();
            CreateMap<Dossier, DossierForCreationUpdateDto>();
            CreateMap<DossierUpdateDto, Dossier>();
            CreateMap<Dossier, DossierUpdateDto>();
        }
    }
}
