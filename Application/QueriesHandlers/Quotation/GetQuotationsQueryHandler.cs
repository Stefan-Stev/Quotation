using Application.Contracts.Dtos.QuotationDtos;
using Application.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueriesHandlers
{
    public class GetQuotationsQueryHandler : IRequestHandler<GetQuotationsQuery, IEnumerable<QuotationGetDto>>
    {
        private readonly IQuotationRepository _quotationRepostiory;
        private readonly IMapper _mapper;

        public GetQuotationsQueryHandler(IQuotationRepository quotationRepostiory, IMapper mapper)
        {
            _quotationRepostiory = quotationRepostiory;
            _mapper = mapper;
        }
        public async Task<IEnumerable<QuotationGetDto>> Handle(GetQuotationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(1000, cancellationToken);
            }
            catch (Exception ex) when (ex is TaskCanceledException)
            {
                throw new TaskCanceledException("The user has cancelled the task!");
            }
            var quotations = await _quotationRepostiory.GetAllQuotations();
            IEnumerable<QuotationGetDto> quotationGetDtos = _mapper.Map<IEnumerable<Quotation>, List<QuotationGetDto>>(quotations);
            return quotationGetDtos;
        }
    }
}
