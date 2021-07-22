using MediatR;
using System;
using Microsoft.AspNetCore.JsonPatch;
using Domain.Entities;

namespace Application.Features.QuotationFeatures.Commands
{
    public class QuotationPatchCommand : IRequest
    {
        public Guid Id { get; set; }

        //public string Name { get; set; }

        //public Guid DossierId { get; set; }

        //public decimal Price { get; set; }

        //public Contracts.Dtos.QuotationDtos.Status Status { get; set; }

        //public DateTime CreationDate { get; set; }

        //public DateTime ValidUntilDate { get; set; }

        public JsonPatchDocument<Quotation> JsonPatchDocument { get; set; }

        //public QuotationPatchCommand(Guid id, string name, Guid dossierId, decimal price, Contracts.Dtos.QuotationDtos.Status status, DateTime creationDate, DateTime validUntilDate, JsonPatchDocument<Quotation> jsonPatchDocument)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.DossierId = dossierId;
        //    this.Price = price;
        //    this.Status = status;
        //    this.CreationDate = CreationDate;
        //    this.ValidUntilDate = validUntilDate;
        //    this.JsonPatchDocument = jsonPatchDocument;
        //}
    }
}
