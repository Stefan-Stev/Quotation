using MediatR;
using System;

namespace Application.Commands
{
    public class DossierUpdateCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
