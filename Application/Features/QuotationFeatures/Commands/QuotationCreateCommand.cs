using Application.Contracts.Dtos.QuotationDtos;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.QuotationFeatures.Commands
{
    public class QuotationCreateCommand : IRequest<Guid>
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters")]
        public string Name { get; set; }

        [Range(0.1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0.1}")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Id of a dossier is required")]
        public Guid DossierId { get; set; }

        public Status Status { get; set; }

        public DateTime DataCreated { get; set; }

        public DateTime DataUntilValid { get; set; }
    }
}
