using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuotationFeatures.Commands
{
    public class QuotationPartialUpdateCommandHandler : IRequestHandler<QuotationPartialUpdateCommand, Guid>
    {
        private readonly IQuotationRepository quotationRepository;

        public QuotationPartialUpdateCommandHandler(IQuotationRepository quotationRepository)
        {
            this.quotationRepository = quotationRepository;
        }
        public async Task<Guid> Handle(QuotationPartialUpdateCommand request, CancellationToken cancellationToken)
        {
            var quotationToBeUpdated = await quotationRepository.GetQuotationById(request.Id);

            if (request.Name != null)
                quotationToBeUpdated.Name = request.Name;
            if (request.DossierId != null)
                quotationToBeUpdated.DossierId = (Guid)request.DossierId;
            if (request.Price != null)
                quotationToBeUpdated.Status = (Domain.Entities.Status)request.Status;
            await quotationRepository.SaveChangeAsync();
            return quotationToBeUpdated.Id;

        }
    }
}
