using Application.Contracts.Dtos.QuotationDtos;
using MediatR;
using System;

namespace Application.Commands
{
    public class QuotationUpdateCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid DossierId { get; set; }
        //public Dossier CurrentDossier { get; set; }

        public decimal Price { get; set; }

        public Status Status { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ValidUntilDate { get; set; }
    }
}
