using Application.Contracts.Dtos.QuotationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class QuotationPartialUpdateCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public float? Price { get; set; }

        public Guid? DossierId { get; set; }

        public Status? Status { get; set; }
    }
}
