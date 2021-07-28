using MediatR;
using System;

namespace Application.Features.DossierFeatures.Commands
{
    public class DossierUpdateCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
