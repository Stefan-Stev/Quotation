using Application.Contracts.Dtos.DossierDtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.DossierFeatures.Queries
{
    public class GetDossiersQuery : IRequest<IEnumerable<DossierGetDto>>
    {
    }
}
