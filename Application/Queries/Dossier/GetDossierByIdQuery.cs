using Application.Contracts.Dtos.DossierDtos;
using MediatR;
using System;

namespace Application.Queries
{
    public class GetDossierByIdQuery : IRequest<DossierGetDto>
    {
        public Guid Id { get; set; }
    }
}
