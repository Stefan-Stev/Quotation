using Application.Contracts.Dtos.QuotationDtos;
using MediatR;
using System;

namespace Application.Queries
{
    public class GetQuotationByIdQuery : IRequest<QuotationGetDto>
    {
        public Guid Id { get; set; }
    }
}
