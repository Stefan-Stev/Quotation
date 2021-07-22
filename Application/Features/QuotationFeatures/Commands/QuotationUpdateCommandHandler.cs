using AutoMapper;
using Domain.Entities;
using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Data.Entity.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuotationFeatures.Commands
{
    public class QuotationUpdateCommandHandler : IRequestHandler<QuotationUpdateCommand, Guid>
    {
        private readonly IQuotationRepository quotationRepository;
        private readonly IMapper mapper;

        public QuotationUpdateCommandHandler(IQuotationRepository quotationRepository, IMapper mapper)
        {
            this.quotationRepository = quotationRepository;
            this.mapper = mapper;
        }
        public async Task<Guid> Handle(QuotationUpdateCommand request, CancellationToken cancellationToken)
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
            var quotation = await quotationRepository.GetQuotationById(request.Id);

            if (quotation == null)
            {
                throw new ObjectNotFoundException("Quotation does not exist");
            }
            var quotationEntity = mapper.Map<Quotation>(request);
            await quotationRepository.Update(quotationEntity);
            return quotation.Id;
        }
    }
}
