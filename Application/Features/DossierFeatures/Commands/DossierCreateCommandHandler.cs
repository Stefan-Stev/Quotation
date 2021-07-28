using AutoMapper;
using Domain.Entities;
using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DossierFeatures.Commands
{
    public class DossierCreateCommandHandler : IRequestHandler<DossierCreateCommand, Guid>
    {
        private readonly IDossierRepository dossierRepository;
        private readonly IMapper mapper;

        public DossierCreateCommandHandler(IDossierRepository dossierRepository, IMapper mapper)
        {
            this.dossierRepository = dossierRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(DossierCreateCommand request, CancellationToken cancellationToken)
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
            var dossier = mapper.Map<Dossier>(request);
            await dossierRepository.CreateDossier(dossier);
            return dossier.Id;
        }
    }
}
