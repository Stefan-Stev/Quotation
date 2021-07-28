using Application.Contracts.Dtos.DossierDtos;
using MediatR;
using System;

namespace Application.Features.DossierFeatures.Queries
{
    public class GetDossierByIdQuery : IRequest<DossierGetDto>
    {
        public Guid Id {get; set;}
    }
}
