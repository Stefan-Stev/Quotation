using MediatR;
using System;

namespace Application.Features.DossierFeatures.Commands
{
    public class DossierDeleteCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
