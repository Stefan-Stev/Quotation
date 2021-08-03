using Application.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Data.Entity.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    class DossierUpdateCommandHandler : IRequestHandler<DossierUpdateCommand, Guid>
    {
        private readonly IDossierRepository dossierRepository;
        private readonly IMapper mapper;

        public DossierUpdateCommandHandler(IDossierRepository dossierRepository, IMapper mapper)
        {
            this.dossierRepository = dossierRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(DossierUpdateCommand request, CancellationToken cancellationToken)
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

            var dossier = dossierRepository.GetDossierById(request.Id);
            if (dossier == null)
            {
                throw new ObjectNotFoundException($"There is no dossier with this Id {request.Id}");
            }

            var dossierToUpdate = mapper.Map<Dossier>(request);
            await dossierRepository.Update(dossierToUpdate);
            return dossierToUpdate.Id;
        }
    }
}
