using Application.Contracts.Dtos.DossierDtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries
{
    public class GetDossiersQuery : IRequest<IEnumerable<DossierGetDto>>
    {
    }
}
