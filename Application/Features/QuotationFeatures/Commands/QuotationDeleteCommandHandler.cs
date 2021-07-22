using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Data.Entity.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuotationFeatures.Commands
{
    class QuotationDeleteCommandHandler : IRequestHandler<QuotationDeleteCommand, Guid>
    {
        private readonly IQuotationRepository quotationRepostory;

        public QuotationDeleteCommandHandler(IQuotationRepository quotationRepostory)
        {
            this.quotationRepostory = quotationRepostory;
        }
        public async Task<Guid> Handle(QuotationDeleteCommand request, CancellationToken cancellationToken)
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
            var quotation = quotationRepostory.GetQuotationById(request.Id).Result;

            if (quotation == null)
            {
                throw new ObjectNotFoundException("Quotation does not exist!");
            }

            await quotationRepostory.DeleteQuotation(quotation);
            return quotation.Id;
        }
    }
}
