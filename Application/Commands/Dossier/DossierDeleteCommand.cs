using MediatR;
using System;

namespace Application.Commands
{
    public class DossierDeleteCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
