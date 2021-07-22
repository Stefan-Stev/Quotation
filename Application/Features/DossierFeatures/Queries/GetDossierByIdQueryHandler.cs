using Application.Contracts.Dtos.DossierDtos;
using AutoMapper;
using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Data.Entity.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DossierFeatures.Queries
{
    public class GetDossierByIdQueryHandler : IRequestHandler<GetDossierByIdQuery,DossierGetDto>
    {
        private readonly IDossierRepository dossierRepository;
        private readonly IMapper mapper;

        public GetDossierByIdQueryHandler(IDossierRepository dossierRepository, IMapper mapper)
        {
            this.dossierRepository = dossierRepository;
            this.mapper = mapper;
        }

        public async Task<DossierGetDto> Handle(GetDossierByIdQuery request, CancellationToken cancellationToken)
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
            var quotation = await dossierRepository.GetDossierById(request.Id);
            if (quotation == null)
                throw new ObjectNotFoundException("No quotation with this Id");
            var quotationDto = mapper.Map<DossierGetDto>(quotation);
            return quotationDto;
        }
    }
}
