using Application.Contracts.Dtos.QuotationDtos;
using AutoMapper;
using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Data.Entity.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuotationFeatures.Queries
{
    public class GetQuotationByIdQueryHandler : IRequestHandler<GetQuotationByIdQuery, QuotationGetDto>
    {
        private readonly IQuotationRepository _quotationRepostiory;
        private readonly IMapper _mapper;

        public GetQuotationByIdQueryHandler(IQuotationRepository quotationRepostiory, IMapper mapper)
        {
            _quotationRepostiory = quotationRepostiory;
            _mapper = mapper;
        }
        public async Task<QuotationGetDto> Handle(GetQuotationByIdQuery request, CancellationToken cancellationToken)
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
            var quotation = await _quotationRepostiory.GetQuotationById(request.Id);
            if (quotation == null)
                throw new ObjectNotFoundException("No quotation with this Id");
            var quotationDto = _mapper.Map<QuotationGetDto>(quotation);
            return quotationDto;
        }
    }
}
