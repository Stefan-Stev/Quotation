using Application.Contracts.Dtos.QuotationDtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.QuotationFeatures.Queries
{
    public class GetQuotationsQuery:IRequest<IEnumerable<QuotationGetDto>>
    {

    }
}
