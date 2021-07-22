using MediatR;
using QuotationsWebApi.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.QuotationFeatures.Commands
{
    public class QuotationPatchCommandHandler : IRequestHandler<QuotationPatchCommand>
    {
        private readonly IQuotationRepository quotationRepository;

        public QuotationPatchCommandHandler(IQuotationRepository quotationRepository)
        {
            this.quotationRepository = quotationRepository;
        }

        public Task<Unit> Handle(QuotationPatchCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //async Task<Unit> IRequestHandler<QuotationPatchCommand, Unit>.Handle(QuotationPatchCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await quotationRepository.GetQuotationById(request.Id);

        //    //if (entity == null)
        //    //{
        //    //    throw new NotFoundException(nameof(), request.Id);
        //    //}

        //    quotationRepository.Patch(request.Id, request.JsonPatchDocument);
        //}
    }
}
