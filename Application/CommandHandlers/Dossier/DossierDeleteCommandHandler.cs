using Application.Commands;
using AutoMapper;
using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Data.Entity.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    class DossierDeleteCommandHandler : IRequestHandler<DossierDeleteCommand, Guid>
    {
        private readonly IDossierRepository dossierRepository;
        private readonly IMapper mapper;

        public DossierDeleteCommandHandler(IDossierRepository dossierRepository, IMapper mapper)
        {
            this.dossierRepository = dossierRepository;
            this.mapper = mapper;
        }
        public async Task<Guid> Handle(DossierDeleteCommand request, CancellationToken cancellationToken)
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
            var dossier = dossierRepository.GetDossierById(request.Id).Result;

            if (dossier == null)
            {
                throw new ObjectNotFoundException("Quotation does not exist!");
            }

            await dossierRepository.DeleteDossier(dossier);
            return dossier.Id;
        }
    }
}
