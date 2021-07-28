using Application.Contracts.Dtos.QuotationDtos;
using MediatR;
using System;

namespace Application.Features.QuotationFeatures.Queries
{
    public class GetQuotationByIdQuery : IRequest<QuotationGetDto>
    {
        public Guid Id { get; set; }
    }
}
