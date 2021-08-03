using Application.Contracts.Dtos.DossierDtos;
using Application.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueriesHandlers
{
    public class GetDossiersQueryHandler : IRequestHandler<GetDossiersQuery, IEnumerable<DossierGetDto>>
    {
        private readonly IDossierRepository dossierRepository;
        private readonly IMapper mapper;

        public GetDossiersQueryHandler(IDossierRepository dossierRepository, IMapper mapper)
        {
            this.dossierRepository = dossierRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<DossierGetDto>> Handle(GetDossiersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(1000, cancellationToken);
            }
            catch (Exception ex) when (ex is TaskCanceledException)
            {
                throw new TaskCanceledException("The user has cancelled the task!");
            }
            var dossiers = await dossierRepository.GetAllDossier();
            IEnumerable<DossierGetDto> quotationGetDtos = mapper.Map<IEnumerable<Dossier>, List<DossierGetDto>>(dossiers);
            return quotationGetDtos;

        }
    }
}
