using Application.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    class QuotationCreateCommandHandler : IRequestHandler<QuotationCreateCommand, Guid>
    {
        private readonly IQuotationRepository quotationRepostiory;
        private readonly IMapper mapper;

        public QuotationCreateCommandHandler(IQuotationRepository quotationRepostiory, IMapper mapper)
        {
            this.quotationRepostiory = quotationRepostiory;
            this.mapper = mapper;
        }
        public async Task<Guid> Handle(QuotationCreateCommand request, CancellationToken cancellationToken)
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
            var quotation = mapper.Map<Quotation>(request);
            await quotationRepostiory.CreateQuotation(quotation);
            return quotation.Id;

        }
    }
}
